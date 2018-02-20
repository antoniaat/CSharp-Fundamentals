internal class Engine
{
    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
    }

    public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, string efficiency, int displacement) : this(model, power)
    {
        this.Efficiency = efficiency;
        this.Displacement = displacement;
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        this.Displacement = displacement;
    }

    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }
}