public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
    }

    public override double OreOutput
    {
        protected set => base.OreOutput = value * Constants.HammerHarvesterOreOutputMultiplier;
    }

    public override double EnergyRequirement
    {
        protected set => base.EnergyRequirement = value * Constants.HammerHarvesterEnergyConsumptionMultiplier;
    }
}