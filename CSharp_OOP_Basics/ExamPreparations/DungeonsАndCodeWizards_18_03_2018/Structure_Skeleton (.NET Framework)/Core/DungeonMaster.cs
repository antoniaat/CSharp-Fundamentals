using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Model;
using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        public List<Character> Party { get; set; }

        public List<Item> Pool = new List<Item>();

        public int LastSurvivor;

        public DungeonMaster()
        {
            this.Party = new List<Character>();
        }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var characterType = args[1];
            var name = args[2];

            Character character = CreateCharacter(faction, characterType, name);
            Party.Add(character);

            return $"{name} joined the party!";
        }

        private Character CreateCharacter(string faction, string characterType, string name)
        {
            Character character;

            if (characterType == "Warrior")
            {
                character = CreateWarriorCharacter(faction, name);
            }

            else if (characterType == "Cleric")
            {
                character = CreateClericCharacter(faction, name);
            }

            else
            {
                throw new ArgumentException($"Invalid character type {characterType}");
            }

            return character;
        }

        private Character CreateClericCharacter(string faction, string name)
        {
            Character character;

            if (faction == Faction.CSharp.ToString())
            {
                character = new Cleric(name, Faction.CSharp);
            }
            else if (faction == Faction.Java.ToString())
            {
                character = new Cleric(name, Faction.Java);
            }
            else
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            return character;
        }

        private Character CreateWarriorCharacter(string faction, string name)
        {
            Character character;

            if (faction == Faction.CSharp.ToString())
            {
                character = new Warrior(name, Faction.CSharp);
            }
            else if (faction == Faction.Java.ToString())
            {
                character = new Warrior(name, Faction.Java);
            }
            else
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            return character;
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            if (itemName == "ArmorRepairKit")
            {
                Pool.Add(new ArmorRepairKit());
            }
            else if (itemName == "HealthPotion")
            {
                Pool.Add(new HealthPotion());
            }
            else if (itemName == "PoisonPotion")
            {
                Pool.Add(new PoisonPotion());
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{ itemName}\"!");
            }

            return $"{itemName} added to Pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            if (Party.Count(x => x.Name == characterName) == 0)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (Pool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in Pool!");
            }

            var item = Pool.Last();

            Party.FirstOrDefault(x => x.Name == characterName)?.Bag.AddItem(item); // Add last item to the bag
            Pool.RemoveAt(Pool.Count - 1);

            return $"{characterName} picked up {item.GetType().Name}";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];
            Character character = Party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item characterItem = character.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            character.UseItem(characterItem);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = Party.FirstOrDefault(x => x.Name == giverName);
            var receiver = Party.FirstOrDefault(x => x.Name == receiverName);
            var item = giver?.Bag.Items.First(x => x.GetType().Name == itemName);
            receiver?.UseItemOn(item, giver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = Party.FirstOrDefault(x => x.Name == giverName);
            var receiver = Party.FirstOrDefault(x => x.Name == receiverName);
            var item = giver?.Bag.Items.First(x => x.GetType().Name == itemName);

            giver?.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();

            foreach (var character in Party
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health))
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = Party.FirstOrDefault(x => x.Name == attackerName);
            var receiver = Party.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null || attacker == null)
            {
                throw new ArgumentException($"{attacker?.Name} cannot attack!");
            }

            if (attacker is Warrior warrior)
            {
                warrior.Attack(receiver);
            }

            return PrintAttack(attacker, attackerName, receiver, receiverName);
        }

        private string PrintAttack(Character attacker, string attackerName, Character receiver, string receiverName)
        {
            var result = new StringBuilder();

            result.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                              $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}" +
                              $"/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healer = Party.FirstOrDefault(x => x.Name == healerName);
            var receiver = Party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            if (healer is Cleric)
            {
                ((Cleric)healer).Heal(receiver);
            }

            return PrintHealing(healer, receiver);
        }

        private string PrintHealing(Character healer, Character receiver)
        {
            var result = new StringBuilder();

            result.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
                              $"{receiver.Name} has {receiver.Health} health now!");

            if (healer.IsAlive == false)
            {
                result.AppendLine($"{healer.Name} cannot heal!");
            }

            return result.ToString();
        }

        public string EndTurn(string[] args)
        {
            var result = new StringBuilder();

            foreach (var per in Party)
            {
                if (per.IsAlive == false)
                {
                    per.Rest();
                    result.AppendLine($"{per.Name} rests ({per.BaseHealth} => {per.Health})");
                }
            }

            if (Party.Count(x => x.IsAlive) == 1 || Party.Count(x => x.IsAlive) == 0)
            {
                LastSurvivor++;
            }

            return result.ToString();
        }

        public bool IsGameOver()
        {
            return LastSurvivor == 1;
        }
    }
}
