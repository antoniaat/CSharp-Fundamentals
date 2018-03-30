using Logger.Interfaces;
using System;
using System.Collections.Generic;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(IAppender appender)
        {
            this.appenders = new List<IAppender> { appender };
        }

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            Console.WriteLine(error);
        }
    }
}