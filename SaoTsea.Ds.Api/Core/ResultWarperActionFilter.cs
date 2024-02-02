using System.Buffers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
	public class ResultWarperActionFilter: IActionFilter
	{
		private static EntityJsonResolver _jsonResolver;
		public ResultWarperActionFilter()
		{
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			
		}

		public void OnActionExecuted(ActionExecutedContext context)
		{
			bool skipStatusResult = context.ActionDescriptor.EndpointMetadata.Any(e => e is SkipStatusResult);

            if (skipStatusResult)
            {
				return;
            }

            if (context.Result is ObjectResult sr)
			{
                _jsonResolver ??= new EntityJsonResolver(true);
                sr.Formatters.Add(new NewtonsoftJsonOutputFormatter(
                    new JsonSerializerSettings()
                    {
                        ContractResolver = _jsonResolver
                    },
                    context.HttpContext.RequestServices.GetService<ArrayPool<char>>(),
                    context.HttpContext.RequestServices.GetService<IOptions<MvcOptions>>().Value,
                    null)
                );

				if (!(sr.Value is StatusResultBase))
				{
					sr.Value = StatusResult.Ok(sr.Value);
				}
			}
		}
	}
}
