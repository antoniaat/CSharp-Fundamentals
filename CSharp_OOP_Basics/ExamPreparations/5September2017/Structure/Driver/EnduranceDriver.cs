public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car, double asd)
        : base(name, car, asd)
    {
        this.FuelConsumptionPerKm = 1.5;
    }
}