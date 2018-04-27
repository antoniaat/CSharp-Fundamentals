using DungeonsAndCodeWizards.Models;

public class CharacterFactory
{
    public Character ProduceCharacter(Faction faction, string characterType, string name)
    {
        Character character = null;

        if (characterType == "Cleric")
        {
            character = new Cleric(name, faction);
        }
        else if (characterType == "Warrior")
        {
            character = new Warrior(name, faction);
        }

        return character;
    }
}
