using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models;

public abstract class Bag
{
    private int capacity;
    private double load;
    //public List<Item> items;

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
    }

    public int Capacity { get; set; }

    public double Load { get; set; }

    public IReadOnlyCollection<Item> Items => this.ItemsList.AsReadOnly();

    public List<Item> ItemsList { get; set; }

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException($"Bag is full!");
        }

        this.ItemsList.Add(item);
    }

    public Item GetItem(string name)
    {
        if (this.ItemsList.Count == 0)
        {
            throw new InvalidOperationException($"Bag is empty!");
        }

        if (this.ItemsList.Count(i => i.GetType().Name == name) == 0)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        Item item = this.ItemsList.FirstOrDefault(i => i.GetType().Name == name);
        this.ItemsList.Remove(item);

        return item;
    }

        
}
