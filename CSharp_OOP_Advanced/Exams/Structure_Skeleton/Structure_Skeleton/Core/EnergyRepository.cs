public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public bool TakeEnergy(double energyNeeded)
    {
        if (this.EnergyStored < energyNeeded)
        {
            return false;
        }

        this.EnergyStored -= energyNeeded;
        return true;
    }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }
}