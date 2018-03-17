public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; set; }

    public override double TotalPower => (this.Power * this.GroundSaturation);

    public override string PrintBender()
    {
        return $"Earth Bender: {Name}, Power: {Power}, Ground Saturation: {GroundSaturation:f2}";
    }
}