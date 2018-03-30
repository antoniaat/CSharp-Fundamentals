using Logger.Interfaces;
using Logger.Loggers;

namespace Logger.Appenders
{
    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.LogFile = logFile;
        }

        public ILogFile LogFile { get; }

        public ErrorLevel Level { get; }

        public int MessagesAppended { get; private set; }

        public ILayout Layout { get; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string reportLevel = this.Level.ToString();
            int messagesCount = this.MessagesAppended;

            string result =
                $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {reportLevel}, " +
                $"Messages appended: {messagesCount}, File size: ${this.logFile.Size}";
            return result;
        }
    }
}