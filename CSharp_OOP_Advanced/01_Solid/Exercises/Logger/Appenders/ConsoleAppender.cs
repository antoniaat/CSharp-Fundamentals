using Logger.Interfaces;
using Logger.Loggers;
using System;

namespace Logger
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }

        public ILayout Layout { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.Level.ToString();
            int messagesCount = this.MessagesAppended;

            string result =
                $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, Messages appended: {messagesCount}";
            return result;
        }
    }
}