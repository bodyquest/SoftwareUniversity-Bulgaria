using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, List<int>> userPoints = new Dictionary<string, List<int>>();
            Dictionary<string, int> languageSubmissions = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                var data = input.Split('-').ToArray();
                string username = data[0];
                string language = data[1];
                int points = 0;
                if (language != "banned")
                {
                    points = int.Parse(data[2]);
                }

                if (!userPoints.ContainsKey(username))
                {
                    userPoints[username] = new List<int>();
                    userPoints[username].Add(points);
                }
                if (data[1] == "banned")
                {
                    userPoints.Remove(username);
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    userPoints[username].Add(points);
                }

                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions[language] = 1;
                }
                else
                {
                    languageSubmissions[language]++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            userPoints = userPoints.OrderByDescending(x => x.Value.Max()).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in userPoints)
            {
                int max = item.Value.Max();
                Console.WriteLine($"{item.Key} | {max}");
            }
            languageSubmissions = languageSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine("Submissions:");
            foreach (var item in languageSubmissions)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
