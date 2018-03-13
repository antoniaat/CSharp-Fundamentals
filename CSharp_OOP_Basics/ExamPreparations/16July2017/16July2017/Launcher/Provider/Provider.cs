using System;

public abstract class Provider
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id { get; protected set; }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException("Every provider energy output need to be positive numbers, less than 10000.");
            }

            this.energyOutput = value;
        }
    }
}
