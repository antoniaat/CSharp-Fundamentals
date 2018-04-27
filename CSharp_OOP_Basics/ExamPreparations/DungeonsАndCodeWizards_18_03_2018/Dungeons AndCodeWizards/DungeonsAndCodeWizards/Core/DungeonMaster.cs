using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Models;

public class DungeonMaster
{
    public List<Character> Party { get; set; }
    public List<Item> Pool { get; set; }

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var characterType = args[1];
        var name = args[2];

        var characterFactory = new CharacterFactory();
        Faction factionValidation = FactionValidation(faction);
        var character = characterFactory.ProduceCharacter(factionValidation, characterType, name);
        Party.Add(character);

        return string.Format(Constants.SuccessfulJoinedPartyMessage, name);
    }

    private Faction FactionValidation(string factionStr)
    {
        switch (factionStr)
        {
            case "Java":
                return Faction.Java;
            case "CSharp":
                return Faction.CSharp;
        }

        throw new ArgumentException($"Invalid faction {factionStr}");
    }

    public string AddItemToPool(string[] args)
    {
        var itemName = args[0];

        // Invalid type validation
        if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
        {
            throw new ArgumentException(string.Format(Constants.InvalidItemTypeErrorMessage, itemName));
        }

        var itemFactory = new ItemFactory();
        var item = itemFactory.ProduceItem(itemName);
        Pool.Add(item);

        return string.Format(Constants.SuccessfulAddedItem, itemName);
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];
        if (CharacterExistInParty(characterName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, characterName));
        }

        if (Pool.Count == 0)
        {
            throw new ArgumentException(Constants.ErrorEmptyPoolMessage);
        }

        var character = Party.FirstOrDefault(ch => ch.Name == characterName);
        var itemName = Pool.Last().GetType().Name;



        character.Bag.AddItem(Pool.Last()); // Pick up last item 
        Pool.RemoveAt(Pool.Count - 1); // Remove last item

        return string.Format(Constants.SuccessfullyPickedItem, characterName, itemName);
    }

    private bool CharacterExistInParty(string characterName)
    {
        return Party.Count(i => i.Name == characterName) != 0;
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];

        if (CharacterExistInParty(characterName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, characterName));
        }

        var character = Party.FirstOrDefault(ch => ch.Name == characterName);
        var item = Pool.FirstOrDefault(i => i.GetType().Name == itemName);

        character.UseItem(item);

        return string.Format(Constants.UsedItemMessage, characterName, itemName);
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        if (CharacterExistInParty(giverName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, giverName));
        }

        if (CharacterExistInParty(receiverName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, receiverName));
        }

        var giver = Party.FirstOrDefault(ch => ch.Name == giverName);
        var receiver = Party.FirstOrDefault(ch => ch.Name == receiverName);

        var item = Pool.FirstOrDefault(i => i.GetType().Name == itemName);

        giver.UseItemOn(item, receiver);

        return string.Format(Constants.UsedItemOnMessage, giverName, itemName, receiverName);
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        if (!CharacterExistInParty(giverName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, giverName));
        }

        if (!CharacterExistInParty(receiverName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, receiverName));
        }

        var giver = Party.FirstOrDefault(ch => ch.Name == giverName);
        var receiver = Party.FirstOrDefault(ch => ch.Name == receiverName);

        var item = Pool.FirstOrDefault(i => i.GetType().Name == itemName);
        giver.GiveCharacterItem(item, receiver);

        return string.Format(Constants.GiveCharacterItem, giverName, receiverName, itemName);
    }

    public string GetStats()
    {
        var characters = new StringBuilder();

        foreach (var character in Party
            .OrderByDescending(ch=>ch.IsAlive)
            .ThenByDescending(ch=>ch.Health))
        {
            characters.AppendLine(character.ToString());
        }

        return characters.ToString();
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var receiverName = args[1];

        if (CharacterExistInParty(attackerName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, attackerName));
        }
        if (CharacterExistInParty(receiverName))
        {
            throw new ArgumentException(string.Format(Constants.CharactedDoesntExistErrorMessage, receiverName));
        }

        var attacker = (Warrior)Party.FirstOrDefault(ch => ch.Name == attackerName);
        var receiver = (Cleric)Party.FirstOrDefault(ch => ch.Name == receiverName);

        if (attacker.IsAlive == false)
        {
            // Attacker cannot attack
            throw new ArgumentException($"{attackerName} cannot attack!");
        }

        attacker.Attack(receiver);

        var sb = new StringBuilder()
            .AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints}" +
                        $" hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and " +
                        $"{receiver.Armor}/{receiver.BaseArmor} AP left!");

        if (receiver.IsAlive == false)
        {
            sb.AppendLine($"{receiverName} is dead!");
        }

        return sb.ToString();
    }

    public string Heal(string[] args)
    {
        throw new NotImplementedException();
    }

    public string EndTurn(string[] args)
    {
        throw new NotImplementedException();
    }

    public bool IsGameOver()
    {
        throw new NotImplementedException();
    }
}
