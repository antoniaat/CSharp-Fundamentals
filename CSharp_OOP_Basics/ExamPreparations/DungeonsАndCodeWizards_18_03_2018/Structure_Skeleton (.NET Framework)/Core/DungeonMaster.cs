using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using DungeonsAndCodeWizards.Model;
using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {

        public DungeonMaster()
        {
            this.Party = new List<Character>();
        }

        public List<Character> Party { get; set; }

       // public List<Character> party = new List<Character>();
        public List<Item> pool = new List<Item>();
        public int lastSurvivor = 0;

        public string JoinParty(string[] args)
        {
            var faction = args[1];
            var characterType = args[2];
            var name = args[3];

            try
            {
                Character character = CreateCharacter(faction, characterType, name);
                Party.Add(character);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return $"{name} joined the party!";
        }

        private Character CreateCharacter(string faction, string characterType, string name)
        {
            Character character;

            if (characterType == "Warrior")
            {
                character = new Warrior(name, new Faction(faction));
            }
            else if (characterType == "Cleric")
            {
                character = new Cleric(name, new Faction(faction));
            }
            else
            {
                throw new ArgumentException($"Invalid character type {characterType}");
            }

            return character;
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[1];

            try
            {
                if (itemName == "ArmorRepairKit")
                {
                    pool.Add(new ArmorRepairKit());
                }
                else if (itemName == "HealthPotion")
                {
                    pool.Add(new HealthPotion());
                }
                else if (itemName == "PoisonPotion")
                {
                    pool.Add(new PoisonPotion());
                }
                else
                {
                    throw new ArgumentException($"Invalid item \"{ itemName}\"!");
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[1];

            if (Party.Count(x => x.Name == characterName) == 0)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (pool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var item = pool.Last();

            Party.First(x => x.Name == characterName).Bag.AddItem(item); // Add last item to the bag
            pool.RemoveAt(pool.Count - 1);

            return $"{characterName} picked up {item.GetType().Name}";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[1];
            var itemName = args[2];

            var character = Party.First(x => x.Name == characterName);
            character.Bag.Items.First(x => x.GetType().Name == itemName).AffectCharacter(character);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return $"{characterName} used {itemName}";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[1];
            var receiverName = args[2];
            var itemName = args[3];

            try
            {
                var giver = Party.FirstOrDefault(x => x.Name == giverName);
                var receiver = Party.FirstOrDefault(x => x.Name == receiverName);
                var item = giver.Bag.Items.First(x => x.GetType().Name == itemName);

                receiver.UseItemOn(item, giver);
            }
            catch (Exception ex)
            {
                // ignored
            }

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[1];
            var receiverName = args[2];
            var itemName = args[3];

            try
            {
                var giver = Party.FirstOrDefault(x => x.Name == giverName);
                var receiver = Party.FirstOrDefault(x => x.Name == receiverName);
                var item = giver.Bag.Items.First(x => x.GetType().Name == itemName);

                giver.GiveCharacterItem(item, receiver);
            }
            catch (Exception ex)
            {
                // ignored
            }

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();

            foreach (var character in Party.OrderByDescending(x => x.IsAlive == false).ThenByDescending(x => x.Health))
            {
                result.AppendLine(character.ToString());
            }

            return result.ToString();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[1];
            var receiverName = args[2];

            var attacker = Party.FirstOrDefault(x => x.Name == attackerName);
            var receiver = Party.FirstOrDefault(x => x.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attacker.Attack(receiver);

            var result = new StringBuilder();

            result.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                        $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (receiver.IsAlive == false)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }
            return result.ToString();
        }

        public string Heal(string[] args)
        {
            var healerName = args[1];
            var healingReceiverName = args[2];

            var healer = Party.FirstOrDefault(x => x.Name == healerName);
            var receiver = Party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healer.Heal(receiver);

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

            if (Party.Count(x => x.IsAlive == false) == 1)
            {
                lastSurvivor++;
            }

            return result.ToString();
        }

        public bool IsGameOver()
        {
            return lastSurvivor == 1;
        }
    }
}
