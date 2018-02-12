namespace _04_HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var hitList = new Dictionary<string, Dictionary<string, string>>();

            ReadPeopleFromConsole(hitList);

            var killer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = killer[1];

            PrintInformationForKilledOne(hitList, name, targetInfoIndex);
        }

        public static void PrintInformationForKilledOne(Dictionary<string, Dictionary<string, string>> hitList, string name, int targetInfoIndex)
        {
            var infoIndexLenght = 0;

            foreach (var kvp in hitList)
            {
                if (kvp.Key == name)
                {
                    Console.WriteLine($"Info on {kvp.Key}:");

                    foreach (var info in kvp.Value.OrderBy(x => x.Key))
                    {
                        infoIndexLenght += info.Key.Length;
                        infoIndexLenght += info.Value.Length;
                        Console.WriteLine($"---{info.Key}: {info.Value}");
                    }

                    Console.WriteLine($"Info index: {infoIndexLenght}");
                    Console.WriteLine(infoIndexLenght >= targetInfoIndex
                        ? "Proceed"
                        : $"Need {targetInfoIndex - infoIndexLenght} more info.");
                }
            }
        }

        public static void ReadPeopleFromConsole(Dictionary<string, Dictionary<string, string>> hitList)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end transmissions")
            {
                var tokens = inputLine.Split(new char[] { '=', ':', ';', });
                var name = tokens[0];

                for (var i = 1; i < tokens.Length; i++)
                {
                    if (!hitList.ContainsKey(name))
                    {
                        hitList.Add(name, new Dictionary<string, string>());
                    }

                    if (i % 2 == 0) continue;

                    if (hitList[name].ContainsKey(tokens[i]))
                    {
                        hitList[name][tokens[i]] = tokens[i + 1];
                    }
                    else
                    {
                        hitList[name].Add(tokens[i], tokens[i + 1]);
                    }
                }
            }
        }
    }
}
