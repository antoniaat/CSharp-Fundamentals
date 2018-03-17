public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; set; }

    public override double TotalPower => this.Power * this.WaterClarity;

    public override string PrintBender()
    {
        return $"Water Bender: {Name}, Power: {Power}, Water Clarity: {WaterClarity:f2}";
    }
}