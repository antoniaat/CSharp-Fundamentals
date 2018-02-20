using System;

public class StartUp
{
    public static void Main()
    {
        var shape = Console.ReadLine();
        var width = int.Parse(Console.ReadLine());
        int height;

        height = shape == "Square" ? width : int.Parse(Console.ReadLine());

        var figure = new DrawingTool(width, height);
        Console.WriteLine(figure.Draw());
    }
}
