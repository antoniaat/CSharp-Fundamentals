using System;

public class StartUp
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();
        var diff = new DateModifier();

        Console.WriteLine(Math.Abs(diff.DifferenceBetweenTwoDates(firstDate, secondDate).Days));
    }
}