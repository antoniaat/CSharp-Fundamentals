using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Model.Bags
{
    public abstract class Bag
    {
        private List<Item> items = new List<Item>();

        private int load;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.Load = load;
        }

        public int Capacity { get; set; }

        public int Load
        {
            get => this.load;

            set
            {
                value = items.Count == 0 ? 0 : Items.Sum(x => x.Weight);

                this.load = value;
            }
        }

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (items.TrueForAll(x => x.GetType().Name != "ArmorRepairKit"
                                      && x.GetType().Name != "HealthPotion"
                                      && x.GetType().Name != "PoisonPotion"))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = Items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
