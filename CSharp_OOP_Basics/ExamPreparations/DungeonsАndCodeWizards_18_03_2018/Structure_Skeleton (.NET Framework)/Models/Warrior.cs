using System;
using DungeonsAndCodeWizards.Model.Bags;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
{
    public class Warrior : Character
    {
        public Warrior(string name, Faction faction) 
            : base(name, faction)
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;
            this.AbilityPoints = 40;
            this.Bag = new Satchel(20);
        }
    }
}
