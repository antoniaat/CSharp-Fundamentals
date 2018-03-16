public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; set; }
}
