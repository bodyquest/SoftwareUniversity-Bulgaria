using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double BASE_HEALTH = 100;
        private const double BASE_ARMOR = 50;
        private const double ABILITY_POINTS = 40;

        public Warrior(string name, Faction faction) 
            : base(name, BASE_HEALTH, BASE_ARMOR, ABILITY_POINTS, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            EnsureBothCharactersAreAlive(character);

            if (this == character) // not sur ehow it works !!!
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
