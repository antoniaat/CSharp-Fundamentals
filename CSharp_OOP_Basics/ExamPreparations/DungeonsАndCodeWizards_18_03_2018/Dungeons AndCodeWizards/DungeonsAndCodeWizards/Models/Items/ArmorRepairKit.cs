namespace DungeonsAndCodeWizards.Models
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
        {
            this.Weight = 10;
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Armor = character.BaseArmor;
            }
        }
    }
}