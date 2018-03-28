using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Model
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        protected Item() { }

        public virtual int Weight { get; set; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
