using Skeleton.Interfaces;
using System;

namespace Skeleton
{
    public class Axe : IWeapon
    {
        public Axe(int attack, int durability)
        {
            this.AttackPoints = attack;
            this.DurabilityPoints = durability;
        }

        public int AttackPoints { get; }

        public int DurabilityPoints { get; private set; }

        public void Attack(ITarget target)
        {
            if (this.DurabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(this.AttackPoints);
            this.DurabilityPoints -= 1;
        }
    }
}