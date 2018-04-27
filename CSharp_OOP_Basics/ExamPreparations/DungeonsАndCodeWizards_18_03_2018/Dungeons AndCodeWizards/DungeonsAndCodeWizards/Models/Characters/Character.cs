using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;

        protected Character(string name, double health, double armor,
            double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.Health = health;
            this.BaseArmor = baseArmor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = isAlive;
            this.RestHealMultiplier = 0.2;
        }

        protected Character(string name, Faction faction) { }

        public virtual double RestHealMultiplier { get; }

        public bool IsAlive { get; set; }

        public Faction Faction { get; set; }

        public Bag Bag { get; set; }

        public double AbilityPoints { get; set; }

        public double Armor
        {
            get => this.armor;

            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.baseArmor)
                {
                    value = this.baseArmor;
                }
            }
        }

        public double BaseArmor { get; set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value > this.baseHealth)
                {
                    value = this.baseHealth;
                }

                this.health = value;
            }
        }

        public double BaseHealth { get; set; }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor - hitPoints < 0)
                {
                    this.Health -= this.Armor - hitPoints;
                }
                else
                {
                    this.Armor -= hitPoints;
                }
            }

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                this.Health += this.BaseHealth * this.RestHealMultiplier;
            }
        }

        public void UseItem(Item item)
        {
            if (IsAlive)
            {
                this.Bag.ItemsList
                    .FirstOrDefault(i => i == item)?
                    .AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                //The item affects the targeted character with the item effect. 
                this.Bag.ItemsList
                    .FirstOrDefault(i => i == item)?
                    .AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                // The targeted character receives the item.
                character.ReceiveItem(item);
                this.Bag.ItemsList.Remove(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.ItemsList.Add(item);
            }
        }

        public override string ToString()
        {
            var status = this.isAlive ? "Alive" : "Dead";

            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, " +
                   $"AP: {this.Armor}/{this.BaseArmor}, Status: {status}";
        }
    }
}