public class DriverFactory
{
    public Driver ProduceDriver(string type, string name, Car car)
    {
        Driver driver = null;

        if (type == "Aggressive")
        {
            driver = new AggressiveDriver(name, car);
        }
        else if (type == "Endurance")
        {
            driver = new EnduranceDriver(name, car);
        }

        return driver;
    }
}
