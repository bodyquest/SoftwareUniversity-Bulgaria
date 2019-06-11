namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Hero
    {
        public Hero()
        {
        }

        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            return $"Hero: {Name} - {Level}lvl" +
            Environment.NewLine +
            "Item:" +
            Environment.NewLine +
            $"  * Strength: {Item.Strength}" +
            Environment.NewLine +
            $"  * Ability: {Item.Ability}" +
            Environment.NewLine +
            $"  * Intelligence: {Item.Intelligence}";
        }
    }
}
