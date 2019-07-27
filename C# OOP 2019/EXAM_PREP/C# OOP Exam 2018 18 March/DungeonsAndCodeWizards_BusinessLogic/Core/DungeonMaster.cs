using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int rounds;


        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalaid faction \"{faction}\"!");
            }

            Character character;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, factionResult);
                    break;
                case "Cleric":
                    character = new Cleric(name, factionResult);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            this.characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item;

            switch (itemName)
            {
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.items.Pop();
            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);

            var item = giver.Bag.GetItem(itemName);
            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var result = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                result.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive": "Dead")}");
            }

            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var result = new StringBuilder();

            string attackerName = args[0];
            string victimName = args[1];

            var attacker = GetCharacter(attackerName);
            var receiver = GetCharacter(victimName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            ((Warrior)attacker).Attack(receiver);

            result.AppendLine(String.Format("{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!", attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().TrimEnd();
            
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            var healer = GetCharacter(healerName);
            var receiver = GetCharacter(receiverName);

            if (!(healer is Cleric))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((Cleric)healer).Heal(receiver);


            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();

            foreach (var character in characters.Where(x => x.IsAlive))
            {
                var healthBefore = character.Health;
                character.Rest();

                sb.AppendLine($"{character.Name} rests ({healthBefore} => {character.Health})");
            }

            if (characters.Count(x => x.IsAlive) <= 1)
            {
                rounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (rounds > 1)
            {
                return true;
            }

            return false;
        }

        private Character GetCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
