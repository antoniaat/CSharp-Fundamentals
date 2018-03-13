public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput += 2 * base.OreOutput; // increases its oreOutput by 200 %
        base.EnergyRequirement += base.EnergyRequirement; // increases its energyRequirement by 100 %
    }
}
