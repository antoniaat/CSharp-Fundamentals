public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity) { }

    public override string Driven(double distance)
    {
        var drivenDistance = this.FuelQuantity - (FuelConsumption + 1.4) * distance;

        if (drivenDistance >= 0)
        {
            this.FuelQuantity -= (FuelConsumption + 1.4) * distance;
            return $"Bus travelled {distance} km";
        }

        return "Bus needs refueling";
    }

    public string DrivenEmpty(double distance)
    {
        var drivenDistance = this.FuelQuantity - (FuelConsumption * distance);

        if (drivenDistance >= 0)
        {
            this.FuelQuantity -= FuelConsumption * distance;
            return $"Bus travelled {distance} km";
        }

        return "Bus needs refueling";
    }
}