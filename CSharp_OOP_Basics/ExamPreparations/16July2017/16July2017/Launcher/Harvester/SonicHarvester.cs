public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, double sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        //UPON INITIALIZATION, divides its given energyRequirement by its sonicFactor.

        this.SonicFactor = energyRequirement / sonicFactor;
    }

    public double SonicFactor { get; protected set; }
}
