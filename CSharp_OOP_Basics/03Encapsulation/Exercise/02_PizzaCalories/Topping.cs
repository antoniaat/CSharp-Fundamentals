using System;
using System.Collections.Generic;

internal class Topping
{
    private Dictionary<string, double> validTypes = new Dictionary<string, double>() { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese" , 1.1}, { "sauce", 0.9 } };

    private double weight;
    private string type;

    public double CalculateCalories()
    {
        return (2 * this.Weight) * this.validTypes[this.Type];
    }

    public Topping(string type, double weight)
    {
        this.Type = type.ToLower();
        this.Weight = weight;
    }

    public string Type
    {
        get => this.type;
        set
        {
            if (!this.validTypes.ContainsKey(value))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }

    public double Weight
    {
        get => this.weight;
        set
        {
            if (value >= 1 && value <= 50)
            {
                this.weight = value;
            }
            else
            {
                throw new ArgumentException($"{this.Type} weight should be in the range[1..50].");
            }
        }
    }
}
