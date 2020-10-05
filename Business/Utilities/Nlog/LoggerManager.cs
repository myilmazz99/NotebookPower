using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Utilities.Nlog
{
    public class LoggerManager : ILoggerService
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
            LogManager.LoadConfiguration(Environment.CurrentDirectory + "/nlog.config");
        }

        public void LogError(Exception ex, string message)
        {
            logger.Error(ex, message);
        }

        public void LogInfo(Exception ex, string message)
        {
            logger.Info(ex, message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(Exception ex, string message)
        {
            logger.Warn(ex, message);
        }
    }
}
