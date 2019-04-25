using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Custom_Comparator
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunction = (a, b) =>
            (a%2 == 0 && b % 2 != 0) ? -1:
            (a%2 != 0 && b % 2 == 0) ? 1:
            a.CompareTo(b);

            Array.Sort(array, new Comparison<int>(sortFunction));
            Console.WriteLine(string.Join(" ", array));

        }
    }
}
