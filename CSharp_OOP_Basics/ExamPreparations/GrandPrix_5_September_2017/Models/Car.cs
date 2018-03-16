using System;

public class Car
{
    private const double maxFuel = 160;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, maxFuel);
        }
    }

    public Tyre Tyre { get; private set; }

    internal void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}