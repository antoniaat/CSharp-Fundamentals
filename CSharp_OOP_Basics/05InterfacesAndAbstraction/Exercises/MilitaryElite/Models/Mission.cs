public class Mission
{
    public string states;

    public Mission(string codeName, string states)
    {
        this.State = states;
        this.CodeName = codeName;
    }

    public string CodeName{ get; set; }

    public string State { get; set; }

    public void CompleteMission()
    {

    }

    public override string ToString()
    {
        return $"  Code Name: {this.CodeName} State: {this.State}";
    }
}
