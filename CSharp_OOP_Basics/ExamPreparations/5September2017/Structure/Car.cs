using System;

public class Car
{
    private double fuelAmount;

    public double HorsePower { get; set; }
    public Tyre Tyre { get; set; }

    public Car(int horsePower,  double fuelAmount, Tyre tyre)
    {
        this.HorsePower = horsePower;
        this.Tyre = tyre;
        this.FuelAmount = fuelAmount;
    }

    // If fuel amount drops below 0 liters you should throw an exception and the driver cannot continue the race.
    // Max capacity 160.
    // If you are given more fuel than needed you should fill up the tank to the maxiumum and nothing else happens.

    public double FuelAmount
    {
        get => this.fuelAmount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The driver cannot continue the race.");
            }

            this.fuelAmount = Math.Min(160, value);
        }
    }
}