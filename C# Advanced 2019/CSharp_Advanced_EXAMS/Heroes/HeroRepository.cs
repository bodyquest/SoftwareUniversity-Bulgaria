namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class HeroRepository
    {
        private Dictionary<string, Hero> heroes;

        public HeroRepository()
        {
            heroes = new Dictionary<string, Hero>();
        }

        public int Count
        {
            get { return heroes.Count; }
        }

        public void Add(Hero hero)
        {
            if (!heroes.ContainsKey(hero.Name))
            {
                heroes.Add(hero.Name, hero);
            }
        }

        public void Remove(string name)
        {
            if (heroes.ContainsKey(name))
            {
                heroes.Remove(name);
            }
        }

        //TO DO : refactor for print out of the found hero
        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = 0;
            Hero strongestHero = new Hero();

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Strength > maxStrength)
                {
                    maxStrength = hero.Value.Item.Strength;
                    strongestHero = hero.Value;
                }
            }

            return strongestHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = 0;
            Hero bestHero = new Hero();

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Ability > maxAbility)
                {
                    maxAbility = hero.Value.Item.Ability;
                    bestHero = hero.Value;
                }
            }

            return bestHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = 0;
            Hero smartestHero = new Hero();

            foreach (var hero in heroes)
            {
                if (hero.Value.Item.Intelligence > maxIntelligence)
                {
                    maxIntelligence = hero.Value.Item.Intelligence;
                    smartestHero = hero.Value;
                }
            }

            return smartestHero;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in heroes)
            {
                result.AppendLine(item.Value.ToString());
            }

            return result.ToString();
        }
    }
}
