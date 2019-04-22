using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_The_V_Logger
{
    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            var input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "Statistics")
            {
                if (input[1] == "followed")
                {
                    string follower = input[0];
                    string followed = input[2];
                    if (follower != followed)
                    {
                        if (dict.ContainsKey(follower) && dict.ContainsKey(followed))
                        {
                            dict[follower]["following"].Add(followed);
                            dict[followed]["followers"].Add(follower);
                        }
                    }
                }
                else
                {
                    string name = input[0];
                    if (!dict.ContainsKey(name))
                    {
                        dict[name] = new Dictionary<string, SortedSet<string>>();
                        dict[name].Add("following", new SortedSet<string>());
                        dict[name].Add("followers", new SortedSet<string>());
                    }
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            //TO PRINT
            Console.WriteLine($"The V-Logger has a total of {dict.Count} vloggers in its logs.");

            var sortedVloggers = dict.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count);

            int count = 0;
            foreach (var item in sortedVloggers)
            {
                count++;
                Console.WriteLine($"{count}. {item.Key} : {item.Value["followers"].Count} followers, {item.Value["following"].Count} following");
                if (count == 1)
                { 
                    foreach (var follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
