internal class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public string Name { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return
            $"{this.Name} {this.Type}";
    }
}