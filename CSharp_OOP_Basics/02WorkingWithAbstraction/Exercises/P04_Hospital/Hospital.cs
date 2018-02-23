using System;
using System.Collections.Generic;
using System.Linq;

public class Hospital
{
    public static void Main()
    {
        var doctors = new Dictionary<string, List<string>>();
        var departments = new Dictionary<string, List<List<string>>>();

        string command;
        while ((command = Console.ReadLine()) != "Output")
        {
            var tokens = command
                .Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var departament = tokens[0];
            var firstName = tokens[1];
            var lastName = tokens[2];
            var patient = tokens[3];
            var fullName = firstName + lastName;

            FillHospital(departments, doctors, fullName, departament);
            bool enoughSpace = CheckForSpace(doctors, departments, departament, patient, fullName);
        }

        ReadCommandsForPrinting(departments, doctors);
    }

    private static bool CheckForSpace(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string departament, string patient, string fullName)
    {
        bool enoughSpace = departments[departament].SelectMany(x => x).Count() < 60;

        if (enoughSpace)
        {
            var room = 0;
            doctors[fullName].Add(patient);

            for (int index = 0; index < departments[departament].Count; index++)
            {
                if (departments[departament][index].Count < 3)
                {
                    room = index;
                    break;
                }
            }

            departments[departament][room].Add(patient);
        }
        return enoughSpace;
    }

    private static void ReadCommandsForPrinting(Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
    {
        string command;

        while ((command = Console.ReadLine()) != "End")
        {
            Print(command, departments, doctors);
        }
    }

    private static void Print(string command, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
    {
        var args = command
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (args.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (args.Length == 2 && int.TryParse(args[1], out int room))
        {
            Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
        }
    }

    private static void FillHospital(Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors, string fullName, string departament)
    {
        if (!doctors.ContainsKey(fullName))
        {
            doctors[fullName] = new List<string>();
        }

        if (!departments.ContainsKey(departament))
        {
            departments[departament] = new List<List<string>>();

            for (int room = 0; room < 20; room++)
            {
                departments[departament].Add(new List<string>());
            }
        }
    }
}
