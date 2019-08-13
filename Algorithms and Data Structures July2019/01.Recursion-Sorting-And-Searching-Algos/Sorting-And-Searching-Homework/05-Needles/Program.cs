using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;


public class Program
{
    public static List<int> indexes = new List<int>();

    public static void Main()
    {
        string input = Console.ReadLine();
        List<int> nums = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        List<int> needles = Console.ReadLine()
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        foreach (var needle in needles)
        {
            bool match = false;

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] >= needle)
                {
                    match = true;
                    GetIndex(nums, i - 1);
                    break;
                }
            }

            if (!match)
            {
                GetIndex(nums, nums.Count - 1);
            }
        }

        Console.WriteLine(string.Join(" ", indexes));
    }

    private static void GetIndex(List<int> nums, int index)
    {
        while (index >= 0)
        {
            if (nums[index] != 0)
            {
                indexes.Add(index + 1);
                return;
            }

            index--;
        }

        indexes.Add(0);
    }
}
