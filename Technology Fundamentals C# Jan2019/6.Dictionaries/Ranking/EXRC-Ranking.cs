using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] login = input.Split(':');
                string contest = login[0];
                string password = login[1];

                if (!contestPass.ContainsKey(contest))
                {
                    contestPass[contest] = password;
                }

                input = Console.ReadLine();
            }
            var contestUserPoints = new Dictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();
            while (input != "end of submissions")
            {
                string[] data = input.Split("=>");
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);
                var user = new Dictionary<string, int>();

                if (contestPass.ContainsKey(contest) && contestPass[contest] == password)
                {
                    if (!contestUserPoints.ContainsKey(username))
                    {
                        
                        user[contest] = points;
                        contestUserPoints[username] = user;
                    }
                    else if (contestUserPoints.ContainsKey(username) && contestUserPoints[username].ContainsKey(contest))
                    {
                        if (points > contestUserPoints[username][contest])
                        {
                            contestUserPoints[username][contest] = points;
                        }
                    }
                    else if (contestUserPoints.ContainsKey(username) && !contestUserPoints[username].ContainsKey(contest))
                    {
                        contestUserPoints[username].Add(contest, points);
                    }
                }

                input = Console.ReadLine();
            }

            int max = 0;
            string bestUser = string.Empty;
            foreach (var user in contestUserPoints)
            {
                
                var total = user.Value.Sum(x => x.Value);
                if (total > max)
                {
                    max = total;
                    bestUser = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {max} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in contestUserPoints.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var kvp in user.Value.OrderByDescending(x=>x.Value))
                {
                    string contest = kvp.Key;
                    int points = kvp.Value;
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
