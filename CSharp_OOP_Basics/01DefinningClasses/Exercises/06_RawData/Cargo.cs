internal class Cargo
{
    public Cargo(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public int Weight { get; set; }
    public string Type { get; set; }
}