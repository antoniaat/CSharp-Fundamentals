using System;
using System.Collections.Generic;

public class StartUp
{
    public static List<Threeuple> Tupples = new List<Threeuple>();

    public static void Main()
    {
        ReadInputLines();
        PrintTupples();
    }

    private static void PrintTupples()
    {
        foreach (var item in Tupples)
        {
            Console.WriteLine($"{item.Item1} -> {item.Item2} -> {item.Item3}");
        }
    }

    private static void ReadInputLines()
    {
        var firstLine = Console.ReadLine().Split();
        Tupples.Add(new Threeuple(firstLine[0] + " " + firstLine[1], firstLine[2], firstLine[3]));

        var secondLine = Console.ReadLine().Split();
        Tupples.Add(secondLine[2] == "drunk"
            ? new Threeuple(secondLine[0], int.Parse(secondLine[1]), true)
            : new Threeuple(secondLine[0], int.Parse(secondLine[1]), false));

        var thirdLine = Console.ReadLine().Split();
        Tupples.Add(new Threeuple(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]));
    }
}