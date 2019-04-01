using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skyscraper
{
    class Skyscraper
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;
            if (n > 3)
            {
                for (int i = 1; i <= n - 3; i++)
                {
                    Console.WriteLine("{0}|{0}", new string(' ', n));
                }
            }
            Console.WriteLine("{0}_|_{0}", new string(' ', n-1));
            for (int i = 1; i <= n-3; i++)
            {
                Console.WriteLine("{0}|-|{0}", new string(' ', n-1));
            }
            Console.WriteLine("{0}_|-|_{0}", new string(' ', n-2));

            for (int i = 1; i < n-2; i++)
            {
                Console.WriteLine("{0}|***|{0}", new string(' ', n - 2));
            }
            Console.WriteLine(" {0}|***|{0} ", new string('_', n - 3));

            //BODY
            for (int i = 1; i < n*4; i++)
            {
                Console.WriteLine(" {0}---{0} ", new string('|', n - 2));
            }
            Console.WriteLine("_{0}---{0}_", new string('|', n - 2));

            //BASE
            for (int i = 1; i <= n -2; i++)
            {
                Console.WriteLine("{0}", new string('|', 2*n +1));
            }
        }
    }
}
