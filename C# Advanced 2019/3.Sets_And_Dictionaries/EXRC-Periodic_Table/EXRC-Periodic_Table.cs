using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Periodic_Table
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> elements = new SortedSet<string>();
            

            for (int i = 0; i < n; i++)
            {
                var chemElements = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < chemElements.Length; j++)
                {
                    elements.Add(chemElements[j]);
                }
            }

            foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
