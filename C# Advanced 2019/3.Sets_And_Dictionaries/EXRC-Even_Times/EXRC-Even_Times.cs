using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Even_Times
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(number))
                {
                    dict[number] = 1;
                }
                else
                {
                    dict[number] ++;
                }
            }

            foreach (var item in dict)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
