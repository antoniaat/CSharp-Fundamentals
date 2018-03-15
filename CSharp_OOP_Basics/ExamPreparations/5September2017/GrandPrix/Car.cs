using System;

public class Car
{
    private double _fuelAmount;

    public Car(int horsePower,  double fuelAmount, Tyre tyre)
    {
        this.HorsePower = horsePower;
        this.Tyre = tyre;
        this.FuelAmount = fuelAmount;
    }
    
    public int HorsePower { get; set; }

    public Tyre Tyre { get; set; }

    public double FuelAmount
    {
        get => this._fuelAmount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.OutOfFuelFailureMessage));
            }

            this._fuelAmount = Math.Min(160, value);
        }
    }
}