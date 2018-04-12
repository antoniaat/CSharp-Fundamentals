using System;
using System.Collections.Generic;

public class Launcher
{
    public static SortedSet<Person> NameComparator = new SortedSet<Person>(new Name());

    public static SortedSet<Person> AgeComparator = new SortedSet<Person>(new Age());

    public static void Main()
    {
        ReadInput();
        PrintPeople();
    }

    private static void PrintPeople()
    {
        foreach (var person in NameComparator)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }

        foreach (var person in AgeComparator)
        {
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }

    private static void ReadInput()
    {
        var n = int.Parse(Console.ReadLine());

        for (int index = 0; index < n; index++)
        {
            var args = Console.ReadLine().Split();

            var name = args[0];
            var age = int.Parse(args[1]);

            var person = new Person(name, age);
            NameComparator.Add(person);
            AgeComparator.Add(person);
        }
    }
}