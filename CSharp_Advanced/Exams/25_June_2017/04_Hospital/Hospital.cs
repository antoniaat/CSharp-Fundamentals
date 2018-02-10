namespace _04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();
            var line = Console.ReadLine();

            while (line != "Output")
            {
                var tokens = line.Split().ToArray();
                var dep = tokens[0];
                var dfn = tokens[1] + " " + tokens[2];
                var patient = tokens[3];

                if (!departments.ContainsKey(dep)) departments[dep] = new List<string>();

                departments[dep].Add(patient);

                if (!doctors.ContainsKey(dfn)) doctors[dfn] = new List<string>();

                doctors[dfn].Add(patient);
                line = Console.ReadLine();
            }

            line = Console.ReadLine().Trim();

            while (line != "End")
            {
                var token = line.Split().ToArray();

                if (token.Length == 1)
                {
                    foreach (var patients in departments[line])
                    {
                        Console.WriteLine(patients);
                    }
                }
                else if (int.TryParse(token[1], out int result))
                {
                    if (int.Parse(token[1]) > 20) continue;
                        
                    var patients = departments[token[0]];
                    var room = patients.Skip(3 * (int.Parse(token[1]) - 1)).Take(3).OrderBy(p => p);

                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var pat = doctors[line];
                    pat.Sort();
                    foreach (var patient in pat)
                    {
                        Console.WriteLine(patient);

                    }
                }
                line = Console.ReadLine();
            }
        }
    }
}
