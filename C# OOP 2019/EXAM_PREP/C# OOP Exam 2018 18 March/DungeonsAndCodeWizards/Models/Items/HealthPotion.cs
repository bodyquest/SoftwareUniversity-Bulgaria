using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int INITIAL_WEIGHT = 5;

        public HealthPotion() 
            : base(INITIAL_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);
            character.Health += 20;
        }
    }
}
