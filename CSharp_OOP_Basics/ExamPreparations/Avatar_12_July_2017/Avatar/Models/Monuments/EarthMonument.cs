public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; set; }

    public override double TotalPower => base.TotalPower += this.EarthAffinity;

    public override string PrintMonument()
    {
        return $"Earth Monument: {Name}, Earth Affinity: {EarthAffinity}";
    }
}