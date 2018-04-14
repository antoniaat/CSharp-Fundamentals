using System;
using DungeonsAndCodeWizards.Intefaces;
using DungeonsAndCodeWizards.Model.Bags;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, faction)
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;
            this.AbilityPoints = 40;
            this.Bag = new Satchel(20);
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException($"Cannot attack self!");
                }

                if (this.Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
                }

                this.TakeDamage(character.AbilityPoints);
            }
        }
    }
}
