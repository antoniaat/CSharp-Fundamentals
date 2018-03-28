using System;
using DungeonsAndCodeWizards.Intefaces;
using DungeonsAndCodeWizards.Model;
using DungeonsAndCodeWizards.Model.Bags;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character : IAttackable, IHealable
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive = true;
        private double restHealMultiplier;

        //protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        //{
        //    this.Name = name;
        //    this.BaseHealth = health;
        //    this.BaseArmor = armor;
        //    this.AbilityPoints = abilityPoints;
        //    this.Bag = bag;
        //    this.Faction = faction;
        //}

        protected Character(string name, Faction faction) // Warior , Cleric
        {
            this.Name = name;
            this.BaseHealth = health;
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

        public Faction Faction { get; protected set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier { get; set; }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                // Taking damage

                if (this.Armor - hitPoints < 0)
                {
                    var diff = this.Armor -= hitPoints;
                    this.Armor -= hitPoints + diff;
                    this.Health -= diff;
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
            this.Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            //if (!IsAlive)
            //{
            //   // item.AffectCharacter();
            //}
        }

        public void UseItemOn(Item item, Character character)
        {
            //For a character to use an item on another character, both of them need to be alive.

            if (IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            // For a character to give another character an item, both of them need to be alive.
            // The targeted character receives the item.

            if (IsAlive && character.IsAlive)
            {
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (IsAlive)
            {
                this.Bag.Items.Add(item);
            }
        }

        public override string ToString()
        {
            var status = isAlive ? "Alive" : "Dead";

            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {status}";
        }

        public void Heal(Character character)
        {
            // If both of those checks pass, the receiving character’s health increases by the healer’s ability points.

            if (character.IsAlive)
            {
                if (this.Faction == character.Faction)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }

                character.Health += this.AbilityPoints;
            }
        }

        public void Attack(Character character)
        {
            if (IsAlive && character.IsAlive)
            {
                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                if (this.Faction == character.Faction)
                {
                    throw new ArgumentException("Friendly fire! Both characters are from {faction} faction!");
                }

                this.TakeDamage(character.AbilityPoints);
            }
        }
    }
}
