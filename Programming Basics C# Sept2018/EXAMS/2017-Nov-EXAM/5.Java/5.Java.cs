using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Java
{
    class Java
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                Console.WriteLine("{0}~ ~ ~{1}", new string(' ', n), new string(' ', 2 * n + 1));
            }
            Console.WriteLine("{0}", new string('=', 3 * n + 5));
            for (int row = 1; row <= n - 2; row++)
            {
                if (row == n / 2)
                {
                    Console.WriteLine("|{0}JAVA{0}|{1}|", new string('~', n), new string(' ', n - 1));
                }
                else
                {
                    Console.WriteLine("|{0}|{1}|", new string('~', 3 * (n + 1) - (n - 1)), new string(' ', n - 1));
                }
            }
            Console.WriteLine("{0}", new string('=', 3 * n + 5));
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine("{0}\\{1}/", new string(' ', row), new string('@', (3 * (n + 1) - (n - 1) - 2 * row)));
            }
            Console.WriteLine("{0}", new string('=', 3 * (n + 1) - (n - 1) + 2));

        } 
    }
}
