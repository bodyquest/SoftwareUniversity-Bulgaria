using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();
            dict.Add("motes", 0);
            dict.Add("fragments", 0);
            dict.Add("shards", 0);

            while (true)
            {
                string [] array = Console.ReadLine().Split();
                string legendaryItem = string.Empty;

                bool hasToBreak = false;

                for (int i = 0; i < array.Length; i += 2)
                {
                    int amount = int.Parse(array[i]);
                    string item = array[i + 1].ToLower();
                    if (item == "shards" || item == "fragments" || item == "motes")
                    {
                        dict[item] += amount;

                        if (dict[item] >= 250)
                        {
                            dict[item] -= 250;
                            if (item == "shards")
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                            }
                            else if (item == "fragments")
                            {
                                Console.WriteLine($"Valanyr obtained!");
                            }
                            else if (item == "motes")
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
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
