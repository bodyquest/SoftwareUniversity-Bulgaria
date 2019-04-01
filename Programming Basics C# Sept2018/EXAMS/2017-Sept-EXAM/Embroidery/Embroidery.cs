using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embroidery
{
    class Embroidery
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n;
            int dots = (3*n-1)/2;
            Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('x', 1));
            Console.WriteLine("{0}/{1}\\{0}", new string('.', dots-1), new string('x', 1));
            Console.WriteLine("{0}x{1}x{0}", new string('.', dots - 1), new string('|', 1));

            for (int i = n / 2; i >= 1; i--)
            {
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', (width - 1 - 2 * i) / 2));
            }
            Console.WriteLine("{0}|{0}", new string('x', (width - 1) / 2));
            for (int i = 1; i <= n/2; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', (width - 1 - 2 * i) / 2));
            }
            Console.WriteLine("{0}/x\\{0}", new string('.', dots - 1));
            Console.WriteLine("{0}\\x/{0}", new string('.', dots - 1));
            for (int i = n / 2; i >= 1; i--)
            {
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', (width - 1 - 2 * i) / 2));
            }
            Console.WriteLine("{0}|{0}", new string('x', (width - 1) / 2));
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine("{0}{1}|{1}{0}", new string('.', i), new string('x', (width - 1 - 2 * i) / 2));
            }
            Console.WriteLine("{0}x|x{0}", new string('.', dots - 1));
            Console.WriteLine("{0}\\x/{0}", new string('.', dots - 1));
            Console.WriteLine("{0}x{0}", new string('.', dots));
        }
    }
}
