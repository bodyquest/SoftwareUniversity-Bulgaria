using System;
using System.Collections.Generic;
using System.Linq;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main()
        {
            int namesCount = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                var entry = Console.ReadLine();
                names.Add(entry);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
