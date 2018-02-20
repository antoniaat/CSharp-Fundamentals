internal class Relative
{
    private string name;
    private string birthday;

    public Relative(string name, string birthday)
    {
        this.Name = name;
        this.Birthday = birthday;
    }

    public string Name { get; set; }
    public string Birthday { get; set; }

    public override string ToString()
    {
        return
            $"{this.Name} {this.Birthday}";
    }
}