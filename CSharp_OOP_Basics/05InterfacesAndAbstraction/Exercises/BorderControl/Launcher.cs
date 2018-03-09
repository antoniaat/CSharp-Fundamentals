using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var citizens = new List<Citizen>();
        var rebels = new List<Rebel>();

        for (int i = 0; i < n; i++)
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (inputLine.Length == 4)
            {
                //Citizen
                citizens.Add(new Citizen(inputLine[0], int.Parse(inputLine[1]), inputLine[2], inputLine[3]));
            }
            else if (inputLine.Length == 3)
            {
                //Rebel
                rebels.Add(new Rebel(inputLine[0], int.Parse(inputLine[1]), inputLine[2]));
            }
        }

        int totalFood = 0;
        string name;
        while ((name = Console.ReadLine()) != "End")
        {
            if (citizens.Count(x => x.Name == name) > 0)
            {
                totalFood += 10;
                //citizens.Where(x => x.Name == name).Select(x=>x.Food += 10);
            }

            if (rebels.Count(x => x.Name == name) > 0)
            {
                totalFood += 5;
                //rebels.Where(x => x.Name == name).Select(x => x.Food += 5);
            }
        }

        Console.WriteLine(totalFood);

        //var fakeId = Console.ReadLine();
        //Print(fakeId, contained);
    }

    private static void Print(string fakeId, List<IIdentable> contained)
    {
        if (contained.Any(b => b.Birthday.EndsWith(fakeId)))
        {
            foreach (var member in contained.Where(m => m.Birthday.EndsWith(fakeId)))
            {
                Console.WriteLine(member.Birthday);
            }
        }
        else Console.WriteLine("<empty output>");
    }

    private static void AddMembers(List<IIdentable> contained, string command)
    {
        var tokens = command.Split();

        if (tokens[0] == "Citizen")
        {
            contained.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
        }
        else if (tokens[0] == "Pet")
        {
            contained.Add(new Pet(tokens[1], tokens[2]));
        }
    }
}
