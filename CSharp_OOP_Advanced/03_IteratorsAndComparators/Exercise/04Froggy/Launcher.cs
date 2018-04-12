using System;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var inputArgs = Console.ReadLine()
            ?.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Console.WriteLine(string.Join(", ", new Lake<int>(inputArgs)));
    }
}