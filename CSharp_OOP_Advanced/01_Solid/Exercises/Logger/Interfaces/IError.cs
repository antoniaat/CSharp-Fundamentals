using System;

namespace Logger.Interfaces
{
    public interface IError : ILevealble
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}