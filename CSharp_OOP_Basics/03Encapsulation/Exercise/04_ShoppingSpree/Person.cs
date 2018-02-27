using System;
using System.Collections.Generic;

internal class Person
{
    private string name;
    private decimal money;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (value == String.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public List<Product> Bag { get; set; }

    public override string ToString()
    {
        return $"{this.Name} - {string.Join(", ", this.Bag)}";
    }
}