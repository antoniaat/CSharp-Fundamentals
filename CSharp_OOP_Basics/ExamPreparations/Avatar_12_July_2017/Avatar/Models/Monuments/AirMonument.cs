public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity)
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

    public override double TotalPower => base.TotalPower += this.AirAffinity;

    public override string PrintMonument()
    {
        return $"Air Monument: {Name}, Air Affinity: {AirAffinity}";
    }
}