using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Find_Evens_Or_Odds
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int start = array[0];
            int end = array[1];

            string typeNumbers = Console.ReadLine();

            List<int> numbers = new List<int>();
            //Predicate<int> filter = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;
            Func<int, bool> filterFunc = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i); 
            }

            Console.WriteLine(string.Join(" ", numbers.Where(filterFunc)));

        }
    }
}
