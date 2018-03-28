using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Model
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
        {
            base.Weight = 10;
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
