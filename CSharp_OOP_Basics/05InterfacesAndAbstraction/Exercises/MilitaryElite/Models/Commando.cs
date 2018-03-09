using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier
{
    private List<Mission> missions = new List<Mission>();

    public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<Mission> Missions { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
        result.AppendLine($"Corps: {base.Corps}");
        result.AppendLine("Missions:");
        result.AppendLine($"{string.Join(Environment.NewLine, this.Missions)}");

        return result.ToString();
    }
}
