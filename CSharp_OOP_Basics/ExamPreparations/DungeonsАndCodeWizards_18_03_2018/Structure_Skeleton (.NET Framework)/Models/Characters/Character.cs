using System;
using DungeonsAndCodeWizards.Model.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;

        private double baseHealth;

        private double health;

        private double armor;

        private double abilityPoints;

        private Bag bag;

        private Faction faction;

        private bool isAlive = true;

        protected Character(string name, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = baseHealth;
            this.Health = health;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; set; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                else if (value > BaseHealth)
                {
                    value = BaseHealth;
                }

                this.health = value;
            }
        }

        public double BaseArmor { get; set; }

        public double Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                else if (value > this.BaseArmor)
                {
                    value = BaseArmor;
                }

                this.armor = value;
            }
        }

        public double AbilityPoints { get; set; }

        public Bag Bag { get; set; }

        public Faction Faction
        {
            get => this.faction;

            protected set
            {
                if (value != Faction.CSharp && value != Faction.Java)
                {
                    throw new ArgumentException($"Invalid faction {value}");
                }

                this.faction = value;
            }
        }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; set; }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                if (this.Armor - hitPoints < 0)
                {
                    var diff = hitPoints - this.Armor;
                    this.Health -= diff;
                    this.Armor = 0;
                }

                else
                {
                    this.Armor -= hitPoints;
                }

                if (Health < 0)
                {
                    IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                this.Health += BaseHealth * RestHealMultiplier;
            }
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            //For a character to use an item on another character, both of them need to be alive.

            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            // The targeted character receives the item.

            if (this.IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
        }

        public override string ToString()
        {
            var status = isAlive ? "Alive" : "Dead";

            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {status}";
        }
    }
}
