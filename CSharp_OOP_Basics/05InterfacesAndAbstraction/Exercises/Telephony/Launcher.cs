using System;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var smartphone = new Smartphone();

        var phones = Console.ReadLine().Split().ToList();
        smartphone.Call(phones);

        var websites = Console.ReadLine().Split().ToList();
        smartphone.Browse(websites);

    }
}
