namespace DungeonsAndCodeWizards.Models
{
    public class HealthPotion : Item
    {
        public HealthPotion()
        {
            this.Weight = 5;
        }

        public void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += 20;
            }
        }
    }
}