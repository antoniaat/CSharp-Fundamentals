using System;

public class StartUp
{
    public static void Main()
    {
        var boxOfStrings = new Box<int>();
        var linesCount = int.Parse(Console.ReadLine());

        for (int index = 0; index < linesCount; index++)
        {
            var inputLine = int.Parse(Console.ReadLine());
            boxOfStrings.Add(inputLine);
        }

        Console.Write(boxOfStrings.ToString());
    }
}