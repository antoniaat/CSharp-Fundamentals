using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    //private IList<IPrivate> privates = new List<IPrivate>();

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        : base(id, firstName, lastName, salary)
    {
        //this.Privates = privates;
    }

    public IList<IPrivate> Privates { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {base.Salary:f2}");
        //result.AppendLine($"Privates:");
        //result.AppendLine($"{this.Privates}");

        return result.ToString();
    }
}
