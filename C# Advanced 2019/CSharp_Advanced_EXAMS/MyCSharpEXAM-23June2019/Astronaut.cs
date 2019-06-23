namespace SpaceStationRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Astronaut
    {
        public Astronaut(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Country { get; set; }

        public override string ToString()
        {
            return $"Astronaut: {Name}, {Age} ({Country})";
        }
    }
}
