public class HarvesterFactory
{
    public Harvester ProduceHarvester(string type, string id, double oreOutput, double energyRequirement,
        int sonicFactor = 0)
    {
        Harvester newHarvester = null;

        if (type == "Sonic")
        {
            newHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else if (type == "Hammer")
        {
            newHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
        }

        return newHarvester;
    }
}