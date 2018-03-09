using System;
using System.Collections.Generic;
using System.Linq;

public class Launcher
{
    public static void Main()
    {
        var privates = new List<Private>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (input == null) continue;

            var tokens = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] == "Private")
            {
                CreateAndPrintPrivate(tokens, privates);
            }

            else if (tokens[0] == "LeutenantGeneral")
            {
                CreateAndPrintLeutenantGeneral(tokens,privates);
            }

            else if (tokens[0] == "Engineer")
            {
                CreateAndPrintEngineer(tokens);
            }

            else if (tokens[0] == "Commando")
            {
                CreateAndPrintCommando(tokens);
            }

            else if (tokens[0] == "Spy")
            {
                CreateAndPrintSpy(tokens);
            }
        }
    }

    private static void CreateAndPrintSpy(string[] tokens)
    {
        try
        {
            var spy = new Spy(int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                tokens[4]);

            Console.WriteLine(spy);
        }
        catch (Exception)
        {
            //ignored
        }
    }

    private static void CreateAndPrintLeutenantGeneral(string[] tokens, List<Private> privates)
    {
        try
        {
            var general = new LeutenantGeneral(int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                decimal.Parse(tokens[4]));

            Console.Write(general);

            for (int i = 5; i < tokens.Length; i++)
            {
                var id = int.Parse(tokens[i]);

                if (privates.Count > 0)
                {
                    Console.WriteLine("Privates:");
                    privates
                        .Where(x => x.Id == id)
                        .ToList()
                        .ForEach(x => Console.WriteLine($"  Name: {x.FirstName} {x.LastName} Id: {x.Id} Salary: {x.Salary:f2}"));
                }
            }
        }
        catch (Exception)
        {
            //ignored
        }
    }

    private static void CreateAndPrintEngineer(string[] tokens)
    {
        try
        {
            var engineer = new Engineer(int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                decimal.Parse(tokens[4]),
                tokens[5]);

            for (int i = tokens.Length - 4; i < tokens.Length; i += 2)
            {
                var partName = tokens[i];
                var hoursWorked = int.Parse(tokens[i + 1]);
                engineer.SetOfRepairs.Add(new Repair(partName, hoursWorked));
            }

            Console.WriteLine(engineer);
        }
        catch (Exception)
        {
            //ignored
        }
    }

    private static void CreateAndPrintCommando(string[] tokens)
    {
        try
        {
            var commando = new Commando(int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                decimal.Parse(tokens[4]),
                tokens[5]);

            for (int i = tokens.Length - 6; i < tokens.Length; i += 2)
            {
                if (tokens[i + 1] == "inProgress" || tokens[i + 1] == "Finished")
                {
                    var codeName = tokens[i];
                    var state = tokens[i + 1];
                    commando.Missions.Add(new Mission(codeName, state));
                }
            }

            Console.WriteLine(commando);
        }
        catch (Exception)
        {
            //ignored
        }
    }

    private static void CreateAndPrintPrivate(string[] tokens, List<Private> privates)
    {
        try
        {
            var privateSoldier = new Private(
                int.Parse(tokens[1]),
                tokens[2],
                tokens[3],
                decimal.Parse(tokens[4]));

            privates.Add(privateSoldier);
            Console.WriteLine(privateSoldier);
        }
        catch (Exception)
        {
            // ignored
        }
    }
}
