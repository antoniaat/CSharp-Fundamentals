using System.Text;

public class Private : Soldier, IPrivate
{
    public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public decimal Salary { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append($"Name: {base.FirstName} {base.LastName} Id: {base.Id} Salary: {this.Salary:f2}");

        return result.ToString();
    }
}
