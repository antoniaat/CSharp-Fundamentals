using System;

public abstract class Product
{
    private double price;

    protected Product(double price, double weight)
    {
        this.Price = price;
        this.Weight = weight;
    }

    public double Weight { get; }

    public double Price
    {
        get => this.price;
        set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"Price cannot be negative!");
            }

            this.price = value;
        }
    }
}