using System.Text;

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

    public Engine(string model, int power, int displacement) : this(model, power)
    {
        this.Displacement = displacement;
        this.Efficiency = "n/a";
    }

    public Engine(string model, int power, string efficiency) : this(model, power)
    {
        this.Efficiency = efficiency;
        this.Displacement = -1;
    }

    public string Model { get; set; }
    public int Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendFormat($"  {Model}:\n");
        sb.AppendFormat($"    Power: {Power}\n");
        sb.AppendFormat("    Displacement: {0}\n", Displacement == -1 ? "n/a" : this.Displacement.ToString());
        sb.AppendFormat($"    Efficiency: {Efficiency}\n");

        return sb.ToString();
    }
}