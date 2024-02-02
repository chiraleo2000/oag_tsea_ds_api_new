using System;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Middleware
{
    public static class ExceptionMiddleware
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        switch (contextFeature.Error)
                        {
                            case AggregateException e:
                                if (e.InnerException is AuthenticationException) {
                                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                }
                                break;
                            case AuthenticationException _:
                                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                break;
                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                break;
                        }

                        string json = JsonConvert.SerializeObject(new StatusResult(
                            contextFeature.Error.Message, context.Response.StatusCode));
                        await context.Response.WriteAsync(json, new System.Text.UTF8Encoding());
                    }
                });
            });
        }
    }
}
