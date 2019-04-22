using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Wardrobe
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                var clothes = input[1].Split(",").ToArray();

                if (!dict.ContainsKey(color))
                {
                    dict[color] = new Dictionary<string, int>();
                    AddClothes(dict, color, clothes);
                }

                else
                {
                    AddClothes(dict, color, clothes);
                }
            }

            var itemToFind = Console.ReadLine().Split(' ').ToArray();
            string colorToFind = itemToFind[0];
            string item = itemToFind[1];

            foreach (var color in dict)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var kvp in color.Value)
                {
                    if (color.Key == colorToFind && kvp.Key == item)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }

        private static void AddClothes(Dictionary<string, Dictionary<string, int>> dict, string color, string[] clothes)
        {
            for (int j = 0; j < clothes.Length; j++)
            {
                if (!dict[color].ContainsKey(clothes[j]))
                {
                    dict[color][clothes[j]] = 1;
                }
                else
                {
                    dict[color][clothes[j]]++;
                }
            }
        }
    }
}
