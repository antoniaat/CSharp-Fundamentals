public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        base.EnergyOutput += 0.5 * base.EnergyOutput;  // increases its energyOutput by 50 %
    }
}
