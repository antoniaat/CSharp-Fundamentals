//  Problems for exercises and homework for the "CSharp OOP Advanced" course at SoftUni.
//  You can check your solutions here: https://judge.softuni.bg/Contests/Practice/Index/710#0

using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        var result = spy.CollectGettersAndSetters("Hacker");
        Console.WriteLine(result);
    }
}