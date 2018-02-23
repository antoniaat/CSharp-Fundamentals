using System;
using System.Collections.Generic;
using System.Linq;

public class GreedyTimes
{
    public static void Main()
    {
        var capacityOfTheBag = long.Parse(Console.ReadLine());
        var safe = Console.ReadLine()
            ?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();

        for (var index = 0; index < safe.Length; index += 2)
        {
            var name = safe[index];
            var count = long.Parse(safe[index + 1]);

            var value = CheckValue(name); ;

            if (value == string.Empty) continue;
            if (capacityOfTheBag < bag.Values.Select(x => x.Values.Sum()).Sum() + count) continue;

            switch (value)
            {
                case "Gem":
                    if (!bag.ContainsKey(value))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (count > bag["Gold"].Values.Sum()) continue;
                        }
                        else continue;
                    }
                    else if (bag[value].Values.Sum() + count > bag["Gold"].Values.Sum()) continue;
                    break;

                case "Cash":
                    if (!bag.ContainsKey(value))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (count > bag["Gem"].Values.Sum()) continue;
                        }
                        else continue;
                    }
                    else if (bag[value].Values.Sum() + count > bag["Gem"].Values.Sum()) continue;
                    break;
            }
            if (!bag.ContainsKey(value)) bag[value] = new Dictionary<string, long>();

            if (!bag[value].ContainsKey(name)) bag[value][name] = 0;

            bag[value][name] += count;
            switch (value)
            {
                case "Gold":
                    break;
                case "Gem":
                    break;
                case "Cash":
                    break;
            }
        }

        Print(bag);
    }


    private static string CheckValue(string name)
    {
        var value = string.Empty;

        if (name.Length == 3) value = "Cash";

        else if (name.ToLower().EndsWith("gem")) value = "Gem";

        else if (name.ToLower() == "gold") value = "Gold";

        return value;
    }

    private static void Print(Dictionary<string, Dictionary<string, long>> bag)
    {
        foreach (var item in bag)
        {
            Console.WriteLine($"<{item.Key}> ${item.Value.Values.Sum()}");

            foreach (var item2 in item.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }
    }
}
