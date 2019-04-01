using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}", new string('#', 4*n + 1));
            for (int row = 1; row <= n; row++)
            {
                if (row == n/2 + 1)
                {
                    Console.Write("{0}{1}{2}@{2}{1}{0}", new string('.', row), new string('#', 2 * n - 2 * row + 1), new string(' ', row-1));
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("{0}{1}{2}{1}{0}", new string('.', row), new string('#', 2 * n - 2 * row + 1), new string(' ', row * 2 - 1));
                    Console.WriteLine();
                }
            }
            for (int row = 1; row <= n; row++)
            {
                    Console.Write("{0}{1}{0}", new string('.', n+row), new string('#', 2 * n - 2 * row + 1));
                    Console.WriteLine();
                
            }
        }
    }
}
