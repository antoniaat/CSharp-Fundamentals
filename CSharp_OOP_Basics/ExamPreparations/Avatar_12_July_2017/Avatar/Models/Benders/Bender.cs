public abstract class Bender
{
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
        this.TotalPower = 0.0;
    }

    public string Name { get; set; }
    public int Power { get; set; }
    public virtual double TotalPower { get; protected set; }

    public virtual string PrintBender()
    {
        return null;
    }
}