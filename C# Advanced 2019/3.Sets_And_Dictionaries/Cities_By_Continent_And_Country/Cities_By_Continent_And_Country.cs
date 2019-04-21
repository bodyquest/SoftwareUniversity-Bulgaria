using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_By_Continent_And_Country
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, List<string>>> dict = new SortedDictionary<string, Dictionary<string, List<string>>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split(" ");
                string continent = info[0];
                string country = info[1];
                string city = info[2];

                if (!dict.ContainsKey(continent))
                {
                    dict[continent] = new Dictionary<string, List<string>>();
                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent][country].Add(city);
                    }
                    else
                    {
                        dict[continent][country].Add(city);
                    }
                }
                else
                {
                    if (!dict[continent].ContainsKey(country))
                    {
                        dict[continent][country].Add(city);
                    }
                    else
                    {
                        dict[continent][country].Add(city);
                    }
                }

            }

            foreach (var continent in dict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($" {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
