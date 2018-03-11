using System;

public abstract class Vehicle
{
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity { get; set; }

    public double FuelConsumption { get; set; }

    public double TankCapacity
    {
        get => this.tankCapacity;
        set
        {
            if (value < this.FuelQuantity)
            {
                value = 0;
            }

            this.tankCapacity = value;
        }
    }

    public abstract string Driven(double distance);

    public virtual void Refueled(double amountOfFuel)
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

        this.FuelQuantity += amountOfFuel;
    }
}