using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_Farming_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            dict["motes"] = 0;
            dict["fragments"] = 0;
            dict["shards"] = 0;

            while (true)
            {
                string[] array = Console.ReadLine().Split();
                string legendaryItem = string.Empty;
                string junkItem = string.Empty;

                bool hasToBreak = false;

                for (int i = 0; i < array.Length; i += 2)
                {
                    int amount = int.Parse(array[i]);
                    string item = array[i + 1].ToLower();
                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        legendaryItem = array[i + 1].ToLower();
                        dict[legendaryItem] += amount;

                        if (dict[legendaryItem] >= 250)
                        {
                            dict[legendaryItem] -= 250;
                            switch (legendaryItem)
                            {
                                case "motes": Console.WriteLine($"Dragonwrath obtained!"); break;
                                case "shards": Console.WriteLine($"Shadowmourne  obtained!"); break;
                                case "fragments": Console.WriteLine($"Valanyr obtained!"); break;
                                default:
                                    break;
                            }
                            hasToBreak = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(item))
                        {
                            junk[item] = amount;
                        }
                        else
                        {
                            junk[item] += amount;
                        }
                    }
                }
                if (hasToBreak)
                {
                    break;
                }
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach (var thing in junk.OrderBy(x => x.Key))
            {
                string material = thing.Key;
                int qty = thing.Value;
                Console.WriteLine($"{material}: {qty}");
            }
        }
    }
}
