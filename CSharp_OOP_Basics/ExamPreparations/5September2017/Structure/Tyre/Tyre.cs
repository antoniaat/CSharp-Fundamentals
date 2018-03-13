using System;

public abstract class Tyre
{
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name { get; protected set; }
    public double Hardness { get; protected set; }

    public virtual double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("The driver cannot continue the race");
            }

            this.degradation = value;
        }
    }
}