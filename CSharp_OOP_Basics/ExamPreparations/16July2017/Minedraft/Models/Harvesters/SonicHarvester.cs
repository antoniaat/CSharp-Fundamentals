public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement = energyRequirement;
    }

    public int SonicFactor { get; protected set; }

    public override double EnergyRequirement
    {
        protected set => base.EnergyRequirement = value / (this.SonicFactor == 0 ? 1 : this.SonicFactor);
    }
}