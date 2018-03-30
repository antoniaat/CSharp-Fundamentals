using System.Collections.Generic;

namespace Logger.Interfaces
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}