using System;
using DungeonsAndCodeWizards.Intefaces;
using DungeonsAndCodeWizards.Model.Bags;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, faction)
        {
            this.Name = name;
            this.Faction = faction;

            this.BaseHealth = 50;
            this.BaseArmor = 25;
            this.AbilityPoints = 40;
            this.Bag = new Backpack(100);
            this.RestHealMultiplier = 0.5;
        }

        
    }
}
