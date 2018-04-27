public class PressureProvider : Provider
{
    public PressureProvider(int id, double energyOutput)
        : base(id, energyOutput)
    {
        this.Durability -= Constants.DurabilityLoss;
        this.EnergyOutput *= Constants.EnergyRequirementMultiplier;
    }
}