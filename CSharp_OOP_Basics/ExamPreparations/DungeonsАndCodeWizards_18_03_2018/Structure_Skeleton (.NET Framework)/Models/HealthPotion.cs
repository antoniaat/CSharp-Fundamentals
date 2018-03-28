using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Model
{
    public class HealthPotion : Item
    {
        public HealthPotion() 
        {
            base.Weight = 5;
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += 20;
            }
        }
    }
}
