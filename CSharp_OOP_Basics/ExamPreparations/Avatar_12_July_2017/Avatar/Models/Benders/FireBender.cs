public class FireBender : Bender
{
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; set; }

    public override double TotalPower => (this.Power * this.HeatAggression);

    public override string PrintBender()
    {
        return $"Fire Bender: {Name}, Power: {Power}, Heat Aggression: {HeatAggression:f2}";
    }
}