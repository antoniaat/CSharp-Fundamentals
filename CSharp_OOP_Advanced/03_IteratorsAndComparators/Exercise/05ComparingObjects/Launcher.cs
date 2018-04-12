using System;
using System.Collections.Generic;

public class Launcher
{
    public static List<Person> PeopleList = new List<Person>();

    public static int NumberOfEqualPeople;

    public static void Main()
    {
        ReadPeople();

        int personNumberAtList = int.Parse(Console.ReadLine());
        personNumberAtList--;

        Person comparePerson = null;
        for (int index = 0; index < PeopleList.Count; index++)
        {
            if (index == personNumberAtList)
            {
                comparePerson = PeopleList[index];
            }
        }

        CountPeople(comparePerson);
        PrintPeople();
    }

    private static void PrintPeople()
    {
        var totalNumberOfPeople = PeopleList.Count;
        var numberOfNotEqualPeople = totalNumberOfPeople - NumberOfEqualPeople;

        Console.WriteLine(NumberOfEqualPeople == 1
            ? "No matches"
            : $"{NumberOfEqualPeople} {numberOfNotEqualPeople} {totalNumberOfPeople}");
    }

    private static void CountPeople(Person comparePerson)
    {
        foreach (var person in PeopleList)
        {
            if (person.CompareTo(comparePerson) == 0)
            {
                NumberOfEqualPeople++;
            }
        }
    }

    private static void ReadPeople()
    {
        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var args = inputLine.Split();
            var name = args[0];
            var age = int.Parse(args[1]);
            var town = args[2];

            PeopleList.Add(new Person(name, age, town));
        }
    }
}