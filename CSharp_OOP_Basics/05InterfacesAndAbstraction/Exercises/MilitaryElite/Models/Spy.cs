using System.Text;

public class Spy : Soldier
{
    public Spy(int id, string firstName, string lastName, string codeNumber) : base(id, firstName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CodeNumber { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Name: {base.FirstName} {base.LastName} Id: {base.Id}");
        result.AppendLine($"Code Number: {this.CodeNumber}");

        return result.ToString();
    }
}
