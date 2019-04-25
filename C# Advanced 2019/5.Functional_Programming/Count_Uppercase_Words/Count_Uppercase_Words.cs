using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main()
        {
            Func<string, bool> checker = n => n[0] == n.ToUpper()[0];
            var words = Console.ReadLine().Split(' ')
                .Where(checker)
                .ToArray();

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
