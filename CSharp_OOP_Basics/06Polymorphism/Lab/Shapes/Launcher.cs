using System;

public class Launcher
{
    public static void Main()
    {
        var rect = new Rectangle(3, 4);
        Console.Write(rect.Draw());
        var circle = new Circle(3);
        Console.Write(circle.Draw());
    }
}
