namespace FightingArena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            gladiators = new List<Gladiator>();
            Name = name;
        }

        public int Count => gladiators.Count;

        public string Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove (string name)
        {
            for (int i = 0; i < gladiators.Count; i++)
            {
                if (gladiators[i].Name == name)
                {
                    gladiators.Remove(gladiators[i]);
                }
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator gladiator = null;

            // check if Min.Value works
            int highest = 0;
            foreach (var item in gladiators)
            {
                if (item.GetStatPower() > highest)
                {
                    highest = item.GetStatPower();
                    gladiator = item;
                }
            }

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator gladiator = null;

            // check if Min.Value works
            int highest = 0;
            foreach (var item in gladiators)
            {
                if (item.GetWeaponPower() > highest)
                {
                    highest = item.GetWeaponPower();
                    gladiator = item;
                }
            }

            return gladiator;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator gladiator = null;

            // check if Min.Value works
            int highest = 0;
            foreach (var item in gladiators)
            {
                if (item.GetTotalPower() > highest)
                {
                    highest = item.GetTotalPower();
                    gladiator = item;
                }
            }

            return gladiator;
        }

        public override string ToString()
        {

            return $"{Name} - {Count} gladiators are participating.";
        }
    }
}
