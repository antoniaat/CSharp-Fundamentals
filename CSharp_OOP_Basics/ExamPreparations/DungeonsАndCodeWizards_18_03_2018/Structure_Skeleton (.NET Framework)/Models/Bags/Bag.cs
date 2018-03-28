using System;
using System.Collections.Generic;
using System.Linq;

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
            this.Items = items;
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

        public List<Item> Items { get; set; }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight >= this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (Items.TrueForAll(x => x.GetType().Name != "ArmorRepairKit"
                                      && x.GetType().Name != "HealthPotion"
                                      && x.GetType().Name != "PoisonPotion"))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            Item item = Items.FirstOrDefault(x => x.GetType().Name == name);
            Items.Remove(item);
            return item;
        }
    }
}
