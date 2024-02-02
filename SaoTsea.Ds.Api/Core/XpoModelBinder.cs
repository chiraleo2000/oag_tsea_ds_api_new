using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SaoTsea.Ds.Api.Core.DataHandlers;

namespace SaoTsea.Ds.Api.Core
{
    public class XpoModelBinder : IModelBinder
    {
        private const int _memoryThreshold = 1024 * 30;
        private readonly IArrayPool<char> _charPool;
        private readonly EntityJsonResolver _jsonResolver;

        public XpoModelBinder()
        {
            _charPool = new JsonArrayPool<char>(ArrayPool<char>.Shared);
            _jsonResolver = new EntityJsonResolver();
        }

        public async Task BindModelAsync(ModelBindingContext ctx)
        {
            Session dbSession = null;

            XpoBindingOptionAttribute options = ctx.ActionContext.ActionDescriptor.EndpointMetadata.OfType<XpoBindingOptionAttribute>().FirstOrDefault();
            DBHandlerCore db = ctx.HttpContext.RequestServices.GetService<DBHandlerCore>();

            if (options != null)
            {
                if (options.UseSameSession)
                {
                    dbSession = db.Session;
                }
                else
                {
                    dbSession = new Session();
                }
            }
            else
            {
                dbSession = new Session();
            }

            var readerFactory = ctx.HttpContext.RequestServices.GetService<IHttpRequestStreamReaderFactory>();
            HttpContext hctx = ctx.HttpContext;
            bool successful = true;
            Exception exception = null;
            object model;
            HttpRequest request = hctx.Request;

            // JSON.Net does synchronous reads. In order to avoid blocking on the stream, we asynchronously
            // read everything into a buffer, and then seek back to the beginning.
            var memoryThreshold = _memoryThreshold;
            var contentLength = request.ContentLength.GetValueOrDefault();
            if (contentLength > 0 && contentLength < memoryThreshold)
            {
                // If the Content-Length is known and is smaller than the default buffer size, use it.
                memoryThreshold = (int)contentLength;
            }

            Stream readStream = new FileBufferingReadStream(request.Body, memoryThreshold);

            await readStream.DrainAsync(CancellationToken.None);
            readStream.Seek(0L, SeekOrigin.Begin);


            using (var streamReader = readerFactory.CreateReader(readStream, Encoding.UTF8))
            {
                using var jsonReader = new JsonTextReader(streamReader)
                {
                    ArrayPool = _charPool,
                    CloseInput = false
                };

                //https://github.com/dotnet/aspnetcore/blob/master/src/Mvc/Mvc.NewtonsoftJson/src/NewtonsoftJsonInputFormatter.cs
                var jsonSetting = new JsonSerializerSettings
                {
                    ContractResolver = _jsonResolver
                };

                jsonSetting.Converters.Add(
                    new EntityJsonResolver.XpoCreateConverter(dbSession, request.Method != "PUT"));

                var jsonSerializer = JsonSerializer.Create(jsonSetting);
                Type type = ctx.ModelType;
                try
                {
                    jsonSerializer.Error += ErrorHandler;
                    jsonSerializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    model = jsonSerializer.Deserialize(jsonReader, type);
                }
                finally
                {
                    jsonSerializer.Error -= ErrorHandler;
                    await readStream.DisposeAsync();
                }
            }

            if (successful)
            {
                ctx.Result = ModelBindingResult.Success(model);
            }

            void ErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs eventArgs)
            {
                successful = false;

                // When ErrorContext.Path does not include ErrorContext.Member, add Member to form full path.
                var path = eventArgs.ErrorContext.Path;
                var member = eventArgs.ErrorContext.Member?.ToString();
                var addMember = !string.IsNullOrEmpty(member);
                if (addMember)
                {
                    // Path.Member case (path.Length < member.Length) needs no further checks.
                    if (path.Length == member.Length)
                    {
                        // Add Member in Path.Memb case but not for Path.Path.
                        addMember = !string.Equals(path, member, StringComparison.Ordinal);
                    }
                    else if (path.Length > member.Length)
                    {
                        // Finally, check whether Path already ends with Member.
                        if (member[0] == '[')
                        {
                            addMember = !path.EndsWith(member, StringComparison.Ordinal);
                        }
                        else
                        {
                            addMember = !path.EndsWith("." + member, StringComparison.Ordinal)
                                        && !path.EndsWith("['" + member + "']", StringComparison.Ordinal)
                                        && !path.EndsWith("[" + member + "]", StringComparison.Ordinal);
                        }
                    }
                }

                if (addMember)
                {
                    path = ModelNames.CreatePropertyModelName(path, member);
                }

                // Handle path combinations such as ""+"Property", "Parent"+"Property", or "Parent"+"[12]".
                var key = ModelNames.CreatePropertyModelName(ctx.ModelName, path);

                exception = eventArgs.ErrorContext.Error;

                var metadata = GetPathMetadata(ctx.ModelMetadata, path);
                var modelStateException = WrapExceptionForModelState(exception);
                ctx.ModelState.TryAddModelError(key, modelStateException, metadata);


                // Error must always be marked as handled
                // Failure to do so can cause the exception to be rethrown at every recursive level and
                // overflow the stack for x64 CLR processes
                eventArgs.ErrorContext.Handled = true;
            }
        }

        private ModelMetadata GetPathMetadata(ModelMetadata metadata, string path)
        {
            var index = 0;
            while (index >= 0 && index < path.Length)
            {
                if (path[index] == '[')
                {
                    // At start of "[0]".
                    if (metadata.ElementMetadata == null)
                    {
                        // Odd case but don't throw just because ErrorContext had an odd-looking path.
                        break;
                    }

                    metadata = metadata.ElementMetadata;
                    index = path.IndexOf(']', index);
                }
                else if (path[index] == '.' || path[index] == ']')
                {
                    // Skip '.' in "prefix.property" or "[0].property" or ']' in "[0]".
                    index++;
                }
                else
                {
                    // At start of "property", "property." or "property[0]".
                    var endIndex = path.IndexOfAny(new[] { '.', '[' }, index);
                    if (endIndex == -1)
                    {
                        endIndex = path.Length;
                    }

                    var propertyName = path.Substring(index, endIndex - index);
                    if (metadata.Properties[propertyName] == null)
                    {
                        // Odd case but don't throw just because ErrorContext had an odd-looking path.
                        break;
                    }

                    metadata = metadata.Properties[propertyName];
                    index = endIndex;
                }
            }

            return metadata;
        }

        private Exception WrapExceptionForModelState(Exception exception)
        {
            // It's not known that Json.NET currently ever raises error events with exceptions
            // other than these two types, but we're being conservative and limiting which ones
            // we regard as having safe messages to expose to clients
            if (exception is JsonReaderException || exception is JsonSerializationException)
            {
                // InputFormatterException specifies that the message is safe to return to a client, it will
                // be added to model state.
                return new InputFormatterException(exception.Message, exception);
            }

            // Not a known exception type, so we're not going to assume that it's safe.
            return exception;
        }

        internal class JsonArrayPool<T> : IArrayPool<T>
        {
            private readonly ArrayPool<T> _inner;

            public JsonArrayPool(ArrayPool<T> inner)
            {
                _inner = inner ?? throw new ArgumentNullException(nameof(inner));
            }

            public T[] Rent(int minimumLength)
            {
                return _inner.Rent(minimumLength);
            }

            public void Return(T[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                _inner.Return(array);
            }
        }
    }
}