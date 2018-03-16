public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity { get; set; }

}
