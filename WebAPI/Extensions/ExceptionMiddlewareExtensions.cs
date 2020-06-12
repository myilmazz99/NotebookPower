using Core.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        if(contextFeature.Error is ValidationException)
                        {
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                        else if(contextFeature.Error is AuthException)
                        {
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                        else
                        {
                            await context.Response.WriteAsync("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
                            //log
                        }

                    }
                });
            });
        }
    }
}
