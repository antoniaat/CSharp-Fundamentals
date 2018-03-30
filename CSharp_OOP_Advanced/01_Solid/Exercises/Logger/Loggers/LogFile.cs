using Logger.Interfaces;
using System;
using System.IO;
using System.Linq;

public class LogFile : ILogFile
{
    private const string DefaultPath = "./data/";

    public LogFile(string fileName)
    {
        this.Path = DefaultPath + fileName;
        InitializeFile();
        this.Size = 0;
    }

    private void InitializeFile()
    {
        Directory.CreateDirectory(DefaultPath);
        File.AppendAllText(this.Path, "");
    }

    public string Path { get; }

    public int Size { get; private set; }

    public void WriteToFile(string errorLog)
    {
        File.AppendAllText(this.Path, errorLog + Environment.NewLine);

        int addedSize = errorLog.Aggregate(0, (current, t) => current + t);

        this.Size += addedSize;
    }
}