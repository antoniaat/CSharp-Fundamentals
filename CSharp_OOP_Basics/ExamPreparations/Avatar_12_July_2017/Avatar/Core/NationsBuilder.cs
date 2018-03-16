using System;
using System.Collections.Generic;
using System.Linq;

public class NationsBuilder
{
    public Dictionary<string, List<Bender>> benders =
        new Dictionary<string, List<Bender>>();

    public Dictionary<string, List<Monument>> monuments =
        new Dictionary<string, List<Monument>>();

    public double AirNationTotalPower = 0.0;
    public double WaterNationTotalPower = 0.0;
    public double EarthNationTotalPower = 0.0;
    public double FireNationTotalPower = 0.0;

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

        //this.TotalPower = benders.Sum(x => x.TotalPower);
        //TODO: Add some logic here … 
    }

    private void AddBender(string type, string name, int power, double secondaryParameter)
    {
        if (type == "Air")
        {
            if (!benders.ContainsKey("Air")) benders.Add("Air", new List<Bender>());
            benders["Air"].Add(new AirBender(name, power, secondaryParameter));
        }

        else if (type == "Earth")
        {
            if (!benders.ContainsKey("Earth")) benders.Add("Earth", new List<Bender>());
            benders["Earth"].Add(new EarthBender(name, power, secondaryParameter));
        }

        else if (type == "Fire")
        {
            if (!benders.ContainsKey("Fire")) benders.Add("Fire", new List<Bender>());
            benders["Fire"].Add(new FireBender(name, power, secondaryParameter));
        }

        else if (type == "Water")
        {
            if (!benders.ContainsKey("Water")) benders.Add("Water", new List<Bender>());
            benders["Water"].Add(new WaterBender(name, power, secondaryParameter));
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
            if (!monuments.ContainsKey("Air")) monuments.Add("Air", new List<Monument>());
            monuments["Air"].Add(new AirMonument(name, affinity));
        }

        else if (type == "Earth")
        {
            if (!monuments.ContainsKey("Earth")) monuments.Add("Earth", new List<Monument>());
            monuments["Earth"].Add(new EarthMonument(name, affinity));
        }

        else if (type == "Fire")
        {
            if (!monuments.ContainsKey("Fire")) monuments.Add("Fire", new List<Monument>());
            monuments["Fire"].Add(new EarthMonument(name, affinity));
        }

        else if (type == "Water")
        {
            if (!monuments.ContainsKey("Water")) monuments.Add("Water", new List<Monument>());
            monuments["Water"].Add(new EarthMonument(name, affinity));
        }
    }

    public string GetStatus(string nationsType)
    {
        return null;
    }
    public void IssueWar(string nationsType)
    {
        //TODO: Add some logic here … 
    }
    public string GetWarsRecord()
    {
        return null;
    }
}
