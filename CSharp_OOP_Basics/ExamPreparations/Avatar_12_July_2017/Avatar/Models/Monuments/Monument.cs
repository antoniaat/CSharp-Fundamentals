using System;

public abstract class Monument
{
    private string name;
    private double totalPower;

    protected Monument(string name)
    {
        this.Name = name;
        this.TotalPower = 0.0;
    }

    public string Name { get; set; }
    public virtual double TotalPower { get; protected set; }

    public virtual string PrintMonument()
    {
        return string.Empty;
    }
}