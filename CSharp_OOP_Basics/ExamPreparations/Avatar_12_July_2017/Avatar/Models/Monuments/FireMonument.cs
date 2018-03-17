public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }

    public override double TotalPower => base.TotalPower += this.FireAffinity;

    public override string PrintMonument()
    {
        return $"Fire Monument: {Name}, Fire Affinity: {FireAffinity}";
    }
}