using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models
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
                //Throw this exception everywhere a character needs to be alive to perform the action.
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
