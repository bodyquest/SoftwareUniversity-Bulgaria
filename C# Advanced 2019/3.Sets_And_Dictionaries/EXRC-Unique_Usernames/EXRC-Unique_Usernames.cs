using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Unique_Usernames
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                usernames.Add(input);
            }

            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
