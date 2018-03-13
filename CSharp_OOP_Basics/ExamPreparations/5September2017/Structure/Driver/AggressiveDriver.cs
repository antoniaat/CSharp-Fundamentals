public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car, double asd)
        : base(name, car, asd)
    {
        this.FuelConsumptionPerKm = 2.7;
        this.Speed *= 1.3;  
    }
}