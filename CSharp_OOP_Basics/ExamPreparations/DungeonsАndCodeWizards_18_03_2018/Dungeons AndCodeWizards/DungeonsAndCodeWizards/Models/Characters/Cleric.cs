using System;
using DungeonsAndCodeWizards.Models;

public class Cleric : Character, IHealable
{
    public Cleric(string name, Faction faction)
        : base(name, faction)
    {
        this.BaseHealth = 50;
        this.BaseArmor = 25;
        this.AbilityPoints = 40;
        this.Bag = new Backpack(100);
    }

    public override double RestHealMultiplier => 0.2;

    public void Heal(Character character)
    {
        if (this.Faction != character.Faction)
        {
            throw new InvalidOperationException($"Cannot heal enemy character!");
        }

        character.Health += this.AbilityPoints;
    }
}
