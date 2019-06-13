namespace Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HitList
    {
        private Dictionary<string, Person> people;

        private int infoIndex;

        public HitList()
        {
            people = new Dictionary<string, Person>();
            this.People = people;
        }

        public Dictionary<string, Person> People { get; set; }

        public void AddPerson(Person person)
        {
            if (!people.ContainsKey(person.Name))
            {
                people.Add(person.Name, person);
            }
        }

        public string KillName(string name)
        {
            StringBuilder info = new StringBuilder();

            if (people.ContainsKey(name))
            {
                info.AppendLine($"Info on {name}:");
                foreach (var kvp in people[name].Kvp)
                {
                    info.AppendLine($"“---{kvp.Key}: {kvp.Value}”");
                    infoIndex += kvp.Key.Length + kvp.Value.Length;
                }
            }

            people[name].InfoIndex = infoIndex;

            return info.ToString() +
                Environment.NewLine +
                $"Info index: {infoIndex}";
        }
    }
}
