namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Item
    {
        public Item(int strenght, int ability, int intelligence)
        {
            Strength = strenght;
            Ability = ability;
            Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            return "Item:" +
            Environment.NewLine +
            $"  * Strength: {Strength}" +
            Environment.NewLine +
            $"  * Ability: {Ability}" +
            Environment.NewLine +
            $"  * Intelligence: {Intelligence}";
        }
    }
}
