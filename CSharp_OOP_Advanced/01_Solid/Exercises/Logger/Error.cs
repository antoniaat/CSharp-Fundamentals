using Logger.Interfaces;
using Logger.Loggers;
using System;

namespace Logger
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public ErrorLevel Level { get; }

        public DateTime DateTime { get; }

        public string Message { get; }
    }
}