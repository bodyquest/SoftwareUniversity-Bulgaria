using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Same_Values_In_Array
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(Double.Parse).ToArray();
            Dictionary<double, int> count = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!count.ContainsKey(numbers[i]))
                {
                    count[numbers[i]] = 1;
                }
                else
                {
                    count[numbers[i]]++;
                }
            }

            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
