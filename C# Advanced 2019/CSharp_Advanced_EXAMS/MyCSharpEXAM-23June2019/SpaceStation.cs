namespace SpaceStationRecruitment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove (string name)
        {
            if (data.FirstOrDefault(s => s.Name == name) != null)
            {
                data.Remove(data.FirstOrDefault(s => s.Name == name));
                return true;
            }
            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldestDude = null;
            int oldest = 0;
            foreach (var dude in data)
            {
                if (dude.Age > oldest)
                {
                    oldest = dude.Age;
                    oldestDude = dude;
                }
            }

            return oldestDude;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut byName = null;
            foreach (var dude in data)
            {
                if (dude.Name == name)
                {
                    byName = dude;
                }
            }

            return byName;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Astronauts working at Space Station {Name}:");
            for (int i = 0; i < data.Count; i++)
            {
                if (i == data.Count -1)
                {
                    report.Append($"{data[i].ToString()}");
                }
                else
                {
                    report.AppendLine($"{data[i].ToString()}");
                }
            }

            return report.ToString().TrimEnd();
        }
    }
}
