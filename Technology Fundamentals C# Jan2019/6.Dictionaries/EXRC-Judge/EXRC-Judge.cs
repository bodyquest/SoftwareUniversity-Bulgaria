using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestUserPoints = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "no more time")
            {
                string[] data = input.Split(" -> ");
                string username = data[0];
                string contest = data[1];
                int points = int.Parse(data[2]);
                var user = new Dictionary<string, int>();

                if (!contestUserPoints.ContainsKey(contest))
                {
                    contestUserPoints[contest] = new Dictionary<string, int>();
                    contestUserPoints[contest].Add(username, points);
                }
                else if (contestUserPoints[contest].ContainsKey(username))
                {
                    if (points > contestUserPoints[contest][username])
                    {
                        contestUserPoints[contest][username] = points;
                    }
                }
                else
                {
                    contestUserPoints[contest].Add(username, points);
                }

                input = Console.ReadLine();
            }

            var list = new Dictionary<string, int>();
            int sum = 0;
            foreach (var contest in contestUserPoints)
            {
                foreach (var user in contest.Value)
                {
                    if (!list.ContainsKey(user.Key))
                    {
                        list[user.Key] = 0;
                    }
                    list[user.Key] += user.Value;
                }
            }

            //TO Print
            foreach (var contest in contestUserPoints)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int position = 1;
                foreach (var item in contest.Value.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
                {
                    string participant = item.Key;
                    int points = item.Value;
                    Console.WriteLine($"{position}. {participant} <::> {points}");
                    position++;
                }
            }

            Console.WriteLine("Individual standings:");
            int ranking = 1;
            foreach (var item in list.OrderByDescending(x => x.Value).ThenBy(x=>x))
            {
                string participant = item.Key;
                int totalPoints = item.Value;
                Console.WriteLine($"{ranking}. {participant} -> {totalPoints}");
                ranking++;
            }
        }
    }
}
