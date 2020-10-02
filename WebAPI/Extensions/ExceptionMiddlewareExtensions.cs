using Business.Utilities.Nlog;
using Core.Utilities;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerService logger)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        ErrorModel errorModel = new ErrorModel();

                        if (contextFeature.Error is ValidationException)
                        {
                            logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;

                            errorModel.StatusCode = StatusCodes.Status400BadRequest;
                            errorModel.ErrorMessage = contextFeature.Error.Message;
                            errorModel.ErrorType = typeof(ValidationException).ToString();

                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                        }
                        else if (contextFeature.Error is AuthException)
                        {
                            logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync(contextFeature.Error.Message);
                        }
                        else if (contextFeature.Error is PaymentException)
                        {
                            logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                            context.Response.StatusCode = StatusCodes.Status400BadRequest;

                            errorModel.StatusCode = StatusCodes.Status400BadRequest;
                            errorModel.ErrorMessage = contextFeature.Error.Message;
                            errorModel.ErrorType = typeof(PaymentException).ToString();

                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                        }
                        else
                        {
                            logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                            errorModel.ErrorMessage = "Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
                            errorModel.StatusCode = StatusCodes.Status500InternalServerError;
                            errorModel.ErrorType = "Internal Server Error";

                            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                        }

                    }
                });
            });
        }
    }
}
