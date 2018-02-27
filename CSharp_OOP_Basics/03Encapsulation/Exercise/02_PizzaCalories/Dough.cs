using System;
using System.Collections.Generic;

internal class Dough
{
    private Dictionary<string, double> validTypes = new Dictionary<string, double>() { { "white", 1.5 }, { "wholegrain", 1 } };
    private Dictionary<string, double> validTechnique = new Dictionary<string, double>() { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
    private double weight;
    private string type;
    private string tech;

    public double CalculateCalories()
    {
        return (2 * this.Weight) * this.validTypes[this.Type] * this.validTechnique[this.Technique];
    }

    public Dough(string type, string technique, double weight)
    {
        this.Type = type;
        this.Technique = technique;
        this.Weight = weight;
    }

    public Dough()
    {
        
    }

    public double Weight
    {
        get => this.weight;
        set
        {
            if (value >= 1 && value <= 200)
            {
                this.weight = value;
            }
            else
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }
    }

    public string Type
    {
        get => this.type;
        set
        {
            if (!this.validTypes.ContainsKey(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.type = value;
        }
    }

    public string Technique
    {
        get => this.tech;
        set
        {
            if (!this.validTechnique.ContainsKey(value))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.tech = value;
        }
    }
}