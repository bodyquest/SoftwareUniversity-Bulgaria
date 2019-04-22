using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Count_Symbols
{
    class Program
    {
        static void Main()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                if (!dict.ContainsKey(text[i]))
                {
                    dict[text[i]] = 1;
                }
                else
                {
                    dict[text[i]] ++;
                }
            }

            foreach (var item in dict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
