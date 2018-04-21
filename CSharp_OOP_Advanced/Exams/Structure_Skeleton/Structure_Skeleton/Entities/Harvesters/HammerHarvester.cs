public class HammerHarvester : Harvester
{
    public HammerHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= Constants.OreOutputMultiplier;
        this.EnergyRequirement *= Constants.EnergyRequirementMultiplier;
    }
}