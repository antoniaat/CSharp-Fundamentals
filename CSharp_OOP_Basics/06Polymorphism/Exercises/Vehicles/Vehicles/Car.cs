public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity) { }

    public override string Driven(double distance)
    {
        var drivenDistance = this.FuelQuantity - (FuelConsumption + 0.9) * distance;

        if (drivenDistance >= 0)
        {
            this.FuelQuantity -= (FuelConsumption + 0.9) * distance;
            return $"Car travelled {distance} km";
        }

        return "Car needs refueling";
    }
}