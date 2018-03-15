public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
    }

    public override double EnergyOutput
    {
        protected set => base.EnergyOutput = value + ((value * Constants.PressureProviderEnergyOutputPercentageModifier) / 100);
    }
}