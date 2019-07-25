namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using DungeonsAndCodeWizards.Models.Characters;

    public class ArmorRepairKit : Item
    {
        private const int INITIAL_WEIGHT = 10;

        public ArmorRepairKit() 
            : base(INITIAL_WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIsAlive(character);
            character.Armor = character.BaseArmor;
        }
    }
}
