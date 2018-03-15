public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car)
        : base(name, car) { }

    public override double FuelConsumptionPerkm
    {
        protected set => base.FuelConsumptionPerkm = Constants.EnduranceDriverFuelConsumptionPerKm;
    }
}