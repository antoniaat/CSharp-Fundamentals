using Minedraft.Models;
using System;
using System.Text;

public abstract class Provider : BaseModel
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public virtual double EnergyOutput
    {
        get => this.energyOutput;

        protected set
        {
            if (value <= 0 || value >= 10000)
            {
                throw new ArgumentException();
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result =
                new StringBuilder()
                    .AppendLine(base.ToString())
                    .Append("Energy Output: " + this.EnergyOutput);

        return result.ToString();
    }
}