public class SolarProvider : Provider
{
    public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability += Constants.SolarProviderDurabilityIncreaser;
    }
}