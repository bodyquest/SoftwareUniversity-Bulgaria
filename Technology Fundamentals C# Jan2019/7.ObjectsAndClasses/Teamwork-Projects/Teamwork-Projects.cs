using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamwork_Projects
{
    class Team
    {
        public string Name { get; set; }
        public string User { get; set; }
        public List<string> Members { get; set; }
    }

    class Program
    {
        static List<Team> teamsList = new List<Team>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var newTeam = Console.ReadLine().Split('-').ToArray();
                List<string> membersList = new List<string>();
                Team team = new Team();
                team.User = newTeam[0];
                team.Name = newTeam[1];
                team.Members = membersList;

                if (!teamsList.Select(x=>x.Name).Contains(team.Name))
                {
                    if (!teamsList.Select(x => x.User).Contains(team.User))
                    {
                        teamsList.Add(team);
                        Console.WriteLine($"Team {team.Name} has been created by {team.User}!");
                    }
                    else
                    {
                        Console.WriteLine($"{team.User} cannot create another team!");
                    }
                }
                else
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                }
            }

            var input = Console.ReadLine().Split("->").ToArray();

            while (!input[0].Equals("end of assignment"))
            {
                string newMember = input[0];
                string teamName = input[1];
                if (!teamsList.Select(x => x.Name).Contains(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teamsList.Select(x => x.Members).Any(x => x.Contains(newMember)) || teamsList.Select(x => x.User).Contains(newMember))
                {
                    Console.WriteLine($"Member {newMember} cannot join team {teamName}!");
                }
                else
                {
                    int teamToJoinIndex = teamsList.FindIndex(x => x.Name == teamName);
                    teamsList[teamToJoinIndex].Members.Add(newMember);
                }

                input = Console.ReadLine().Split("->").ToArray();
            }

            var toDisband = teamsList.OrderBy(x => x.Name).Where(x => x.Members.Count == 0);
            //// SORT ALL TEAMS by Member count THEN by Name
            var sortedList = teamsList.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name).Where(x => x.Members.Count > 0);
            foreach (var team in sortedList)
            {
                Console.WriteLine($"{team.Name}\r\n- {team.User}");
                foreach (var member in team.Members.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var item in toDisband)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
