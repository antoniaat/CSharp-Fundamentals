using System;

public abstract class Provider : IProvider
{
    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = Constants.InitialDurability;
    }

    public int ID { get; protected set; }

    public double EnergyOutput { get; protected set; }

    public double Durability
    {
        get => this.durability;

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.ID));
            }

            this.durability = value;
        }
    }

    public double Produce() => this.EnergyOutput;

    public void Broke() => this.Durability -= Constants.DurabilityDecreaser;

    public void Repair(double val) => this.Durability += val;

    public override string ToString()
    {
        return this.GetType().Name
               + Environment.NewLine
               + $"Durability: {this.Durability}";
    }
}