namespace Logger.Interfaces
{
    public interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string errorLog);
    }
}