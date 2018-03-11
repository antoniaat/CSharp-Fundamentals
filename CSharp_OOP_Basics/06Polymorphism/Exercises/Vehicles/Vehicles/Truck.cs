using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity) { }

    public override string Driven(double distance)
    {
        var fuelNeeded = this.FuelQuantity - (this.FuelConsumption + 1.6) * distance;

        if (fuelNeeded >= 0)
        {
            this.FuelQuantity -= (this.FuelConsumption + 1.6) * distance;
            return $"Truck travelled {distance} km";
        }

        return "Truck needs refueling";
    }

    public override void Refueled(double amountOfFuel)
    {
        if (amountOfFuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        var checkForEnoughSpace = (this.TankCapacity - this.FuelQuantity) < amountOfFuel;

        if (checkForEnoughSpace)
        {
            throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
        }

        var fuel = (amountOfFuel * 95) / 100;
        this.FuelQuantity += fuel;
    }
}