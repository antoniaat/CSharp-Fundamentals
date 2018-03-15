public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
        : base(name, car) { }

    public override double FuelConsumptionPerkm
    {
        protected set => base.FuelConsumptionPerkm = Constants.AggressiveDriverFuelConsumptionPerKm;
    }

    public override double Speed
    {
        protected set => base.Speed *= Constants.AggressiveDriverSpeed;
    }
}