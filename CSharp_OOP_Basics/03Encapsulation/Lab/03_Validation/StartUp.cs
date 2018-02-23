using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();

        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            try
            {
                var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));
                persons.Add(person);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //var bonus = decimal.Parse(Console.ReadLine()); // This solution is for previous exercise

        //persons.ForEach(p => p.IncreaseSalary(bonus));

        var team = new Team("Softuni");

        foreach (var p in persons)
        {
            team.AddPlayer(p);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");

        // persons.ForEach(p => Console.WriteLine(p.ToString()));
    }
}