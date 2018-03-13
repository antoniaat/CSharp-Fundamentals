public class ProviderFactory
{
    public Provider ProduceProvider(string type, string id, double energyOutput)
    {
        Provider newProvider = null;

        if (type == "Solar")
        {
            newProvider = new SolarProvider(id, energyOutput);
        }
        else if (type == "Pressure")
        {
            newProvider = new PressureProvider(id, energyOutput);
        }

        return newProvider;
    }
}
