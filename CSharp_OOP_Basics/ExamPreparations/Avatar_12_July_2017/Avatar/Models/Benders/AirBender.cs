public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; set; }

    public override double TotalPower => (this.Power * this.AerialIntegrity);

    public override string PrintBender()
    {
        return $"Air Bender: {Name}, Power: {Power}, Aerial Integrity: {AerialIntegrity:f2}";
    }
}