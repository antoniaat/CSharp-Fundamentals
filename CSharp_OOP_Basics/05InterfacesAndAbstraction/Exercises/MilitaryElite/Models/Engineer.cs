using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier
{
    public Engineer(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary, corps)
    {
        this.SetOfRepairs = new List<Repair>();
    }

    public List<Repair> SetOfRepairs { get; set; }

    public decimal Salary { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
        result.AppendLine($"Corps: {base.Corps}");
        result.AppendLine($"Repairs:{Environment.NewLine}{string.Join(Environment.NewLine, this.SetOfRepairs)}");

        return result.ToString();
    }
}
