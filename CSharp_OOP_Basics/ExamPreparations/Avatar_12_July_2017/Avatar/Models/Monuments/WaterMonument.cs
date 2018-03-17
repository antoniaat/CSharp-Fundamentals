public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity { get; set; }

    public override double TotalPower => base.TotalPower += this.WaterAffinity;

    public override string PrintMonument()
    {
        return $"Water Monument: {Name}, Water Affinity: {WaterAffinity}";
    }
}