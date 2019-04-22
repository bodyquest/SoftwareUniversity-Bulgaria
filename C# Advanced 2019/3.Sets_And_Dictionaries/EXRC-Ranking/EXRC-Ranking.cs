using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Ranking
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(':').ToArray();
            Dictionary<string, string> contestInfo = new Dictionary<string, string>();

            while (input[0] != "end of contests")
            {
                string contest = input[0];
                string password = input[1];
                if (!contestInfo.ContainsKey(contest))
                {
                    contestInfo.Add(contest, password);
                }

                input = Console.ReadLine().Split(':').ToArray();
            }

            var userSubmissions = Console.ReadLine().Split("=>").ToArray();
            var dict = new Dictionary<string, Dictionary<string, int>>();

            while (userSubmissions[0] != "end of submissions")
            {
                string contest = userSubmissions[0];
                string password = userSubmissions[1];
                string user = userSubmissions[2];
                int points = int.Parse(userSubmissions[3]);
                foreach (var item in contestInfo)
                {
                    if (item.Key == contest && item.Value == password)
                    {
                        if (!dict.ContainsKey(user))
                        {
                            dict[user] = new Dictionary<string, int>();
                            if (!dict[user].ContainsKey(contest))
                            {
                                dict[user].Add(contest, points);
                            }
                            else
                            {
                                if (dict[user][contest] < points)
                                {
                                    dict[user][contest] = points;
                                }
                            }
                        }
                        else
                        {
                            if (!dict[user].ContainsKey(contest))
                            {
                                dict[user].Add(contest, points);
                            }
                            else
                            {
                                if (dict[user][contest] < points)
                                {
                                    dict[user][contest] = points;
                                }
                            }
                        }
                    }
                }

                userSubmissions = Console.ReadLine().Split("=>").ToArray();
            }

            //TO PRINT
            string best = string.Empty;
            var sorted = dict.OrderByDescending(u => u.Value.Values.Sum());
            foreach (var item in sorted)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
                best = item.Key;
                break;
            }

            Console.WriteLine($"Ranking:");
            foreach (var user in dict.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"# {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
