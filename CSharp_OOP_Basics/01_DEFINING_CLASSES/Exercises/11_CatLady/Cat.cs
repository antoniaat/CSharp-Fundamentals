internal class Cat
{
    private string name;
    private string type;
    private double characteristic;

    public Cat(string name, string type, double characteristic)
    {
        this.Name = name;
        this.Type = type;
        this.Characteristic = characteristic;
    }

    public string Name { get; set; }
    public string Type { get; set; }
    public double Characteristic { get; set; }
}
