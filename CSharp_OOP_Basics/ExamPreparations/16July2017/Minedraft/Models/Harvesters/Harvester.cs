using Minedraft.Models;
using System;
using System.Text;

public abstract class Harvester : BaseModel
{
    private double oreOutput;

    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public virtual double OreOutput
    {
        get => this.oreOutput;

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            this.oreOutput = value;
        }
    }

    public virtual double EnergyRequirement
    {
        get => this.energyRequirement;

        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException();
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result =
            new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine("Ore Output: " + this.OreOutput)
            .Append("Energy Requirement: " + this.EnergyRequirement);

        return result.ToString();
    }
}