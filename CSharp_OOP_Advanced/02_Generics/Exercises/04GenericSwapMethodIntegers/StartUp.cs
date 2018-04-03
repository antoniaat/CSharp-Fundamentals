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

        var indexexToSwap = Console.ReadLine().Split();
        var firstIndex = int.Parse(indexexToSwap[0]);
        var secondIndex = int.Parse(indexexToSwap[1]);

        boxOfStrings.Swap(firstIndex, secondIndex);

        Console.Write(boxOfStrings.ToString());
    }
}