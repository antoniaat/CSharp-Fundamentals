public class SonicHarvester : Harvester
{
    public SonicHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement / Constants.EnergyRequirementDivider)
    {
        this.Durability -= Constants.DurabilityLoss;
    }
}