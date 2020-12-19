using Logger.Appenders;
using Logger.Enumerations;
using System.Collections.Generic;

namespace Logger.Logger
{
    public class LoggerType : ILogger
    {
        public LoggerType(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public ICollection<IAppender> Appenders { get; private set; }

        public void Critical(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, Level.CRITICAL, message);
            }
        }

        public void Error(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, Level.ERROR, message);
            }
        }

        public void Fatal(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, Level.FATAL, message);
            }
        }

        public void Info(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, Level.INFO, message);
            }
        }

        public void Warning(string date, string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(date, Level.WARNING, message);
            }
        }
    }
}
