using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                var tokens = Console.ReadLine().Split().ToArray();
                Person p = new Person(tokens[0], tokens[1], int.Parse(tokens[2]), decimal.Parse(tokens[3]));
                people.Add(p);
            }

            Team team = new Team("SoftUni");

            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players");

        }
    }
}
