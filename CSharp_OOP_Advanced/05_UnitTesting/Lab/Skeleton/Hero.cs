using Skeleton.Interfaces;

namespace Skeleton
{
    public class Hero
    {
        public Hero(string name, IWeapon weapon)
        {
            this.Name = name;
            this.Experience = 0;
            this.Weapon = weapon;
        }

        public string Name { get; }

        public int Experience { get; private set; }

        public IWeapon Weapon { get; }

        public void Attack(ITarget target)
        {
            this.Weapon.Attack(target);

            if (target.IsDead())
            {
                this.Experience += target.GiveExperience();
            }
        }
    }
}