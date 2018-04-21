using System;
using Skeleton;

public class StartUp
{
    public static void Main()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Console.WriteLine(dummy.Health);
    }
}