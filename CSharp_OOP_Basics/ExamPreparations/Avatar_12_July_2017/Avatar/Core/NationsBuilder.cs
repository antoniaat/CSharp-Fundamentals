using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private readonly Dictionary<string, List<Bender>> Benders =
        new Dictionary<string, List<Bender>>();

    private readonly Dictionary<string, List<Monument>> Monuments =
        new Dictionary<string, List<Monument>>();

    private readonly Dictionary<string, double> NationsTotalPower =
        new Dictionary<string, double>();

    public double CountWars;

    public StringBuilder WarsResult = new StringBuilder();

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);

        try
        {
            AddBender(type, name, power, secondaryParameter);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void AddBender(string type, string name, int power, double secondaryParameter)
    {
        if (type == "Air")
        {
            if (!Benders.ContainsKey("Air"))
            {
                Benders.Add("Air", new List<Bender>());
            }

            Benders["Air"].Add(new AirBender(name, power, secondaryParameter));
        }

        else if (type == "Earth")
        {
            if (!Benders.ContainsKey("Earth"))
            {
                Benders.Add("Earth", new List<Bender>());
            }

            Benders["Earth"].Add(new EarthBender(name, power, secondaryParameter));
        }
        else if (type == "Fire")
        {
            if (!Benders.ContainsKey("Fire"))
            {
                Benders.Add("Fire", new List<Bender>());
            }

            Benders["Fire"].Add(new FireBender(name, power, secondaryParameter));
        }
        else if (type == "Water")
        {
            if (!Benders.ContainsKey("Water"))
            {
                Benders.Add("Water", new List<Bender>());
            }

            Benders["Water"].Add(new WaterBender(name, power, secondaryParameter));
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        try
        {
            AddMonument(type, name, affinity);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private void AddMonument(string type, string name, int affinity)
    {
        if (type == "Air")
        {
            if (!Monuments.ContainsKey("Air"))
            {
                Monuments.Add("Air", new List<Monument>());
            }

            Monuments["Air"].Add(new AirMonument(name, affinity));
        }
        else if (type == "Earth")
        {
            if (!Monuments.ContainsKey("Earth"))
            {
                Monuments.Add("Earth", new List<Monument>());
            }

            Monuments["Earth"].Add(new EarthMonument(name, affinity));
        }
        else if (type == "Fire")
        {
            if (!Monuments.ContainsKey("Fire"))
            {
                Monuments.Add("Fire", new List<Monument>());
            }

            Monuments["Fire"].Add(new FireMonument(name, affinity));
        }
        else if (type == "Water")
        {
            if (!Monuments.ContainsKey("Water"))
            {
                Monuments.Add("Water", new List<Monument>());
            }

            Monuments["Water"].Add(new WaterMonument(name, affinity));
        }
    }

    public string GetStatus(string nationsType)
    {
        var result = new StringBuilder();

        result.Append(GetBendersStatus(nationsType));
        result.Append(GetMonumentsStatus(nationsType));

        return result.ToString();
    }

    private string GetMonumentsStatus(string nationsType)
    {
        if (!Monuments.ContainsKey(nationsType) || Monuments[nationsType].Count == 0)
        {
            return $"Monuments: None{Environment.NewLine}";
        }

        var result = new StringBuilder();

        foreach (var kvp in Monuments)
        {
            if (kvp.Key == nationsType)
            {
                result.AppendLine($"Monuments:");

                foreach (var monument in kvp.Value)
                {
                   result.AppendLine($"###{monument.PrintMonument()}");
                }
            }
        }

        return result.ToString();
    }

    private string GetBendersStatus(string nationsType)
    {
        var result = new StringBuilder()
            .AppendLine($"{nationsType} Nation");

        if (!Benders.ContainsKey(nationsType) || Benders[nationsType].Count == 0)
        {
            return result + "Benders: None" + Environment.NewLine;
        }

        foreach (var kvp in Benders)
        {
            if (kvp.Key == nationsType)
            {
                result.AppendLine($"Benders:");

                foreach (var bender in kvp.Value)
                {
                    result.AppendLine($"###{bender.PrintBender()}");
                }
            }
        }

        return result.ToString();
    }

    public void IssueWar(string nationsType)
    {
        CountWars++;
        CalculateNationsTotalPower();

        var winnerNation = NationsTotalPower.OrderByDescending(x => x.Value).First().Key;
        WarsResult.AppendLine($"War {CountWars} issued by {nationsType}");

        PrintWinner(winnerNation);
    }

    private void PrintWinner(string winnerNation)
    {
        // Print benders
        foreach (var bender in Benders)
        {
            if (bender.Key != winnerNation)
            {
                bender.Value.Clear();
            }
        }

        // Print monuments
        foreach (var monument in Monuments)
        {
            if (monument.Key != winnerNation)
            {
                monument.Value.Clear();
            }
        }
    }

    private void CalculateNationsTotalPower()
    {
        var nation = "Air";
        CalculateNation(nation);

        nation = "Fire";
        CalculateNation(nation);

        nation = "Earth";
        CalculateNation(nation);

        nation = "Water";
        CalculateNation(nation);
    }

    private void CalculateNation(string nation)
    {
        if (!NationsTotalPower.ContainsKey(nation))
        {
            NationsTotalPower.Add(nation, 0.0);
        }

        if (Benders.Count != 0 && Benders.ContainsKey(nation) && Benders[nation].Count != 0)
        {
            NationsTotalPower[nation] += Benders[nation].Sum(x => x.TotalPower);
        }

        if (Monuments.Count != 0 && Monuments.ContainsKey(nation) && Monuments[nation].Count != 0)
        {
            NationsTotalPower[nation] += (NationsTotalPower[nation] / 100) * Monuments[nation].Sum(x => x.TotalPower);
        }
    }

    public string GetWarsRecord()
    {
        return null;
    }
}