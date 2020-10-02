using Business.Utilities.Nlog;
using Castle.DynamicProxy;
using Core.Utilities.JsonConverter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Aspects
{
    public class Logger : IInterceptor
    {
        private readonly ILoggerService _logger;
        private readonly IJsonHelper _json;

        public Logger(ILoggerService logger, IJsonHelper json)
        {
            _logger = logger;
            _json = json;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.LogInfo($"Calling method {invocation.Method.Name} with parameters ${_json.SerializeObject(invocation.Arguments)}");

            invocation.Proceed();

            _logger.LogInfo($"Done calling method {invocation.Method.Name}");
        }
    }
}
