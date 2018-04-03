using System;

public class StartUp
{
    public static void Main()
    {
        var boxOfStrings = new Box<string>();
        var linesCount = int.Parse(Console.ReadLine());

        for (int index = 0; index < linesCount; index++)
        {
            var inputLine = Console.ReadLine();
            boxOfStrings.Add(inputLine);
        }

        string element = Console.ReadLine();
        Console.Write(boxOfStrings.CompareTo(element));
    }
}