using System;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        public int Weight { get; protected set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        protected Item() { }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }
        }
    }
}
