using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Sunglasses
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Console.Write(new string('*', 2*n));
            Console.Write(new string(' ', n));
            Console.WriteLine(new string('*', 2 * n));

            for (int i = 0; i < n-2; i++)
            {
                Console.Write(new string('*', 1));
                Console.Write(new string('/', 2 * n - 2));
                Console.Write(new string('*', 1));

                var center = (n-2) / 2;  //WHEN if (i==(n-2) / 2), ROWS 24-32 not needed
                if (n % 2 == 0)
                {
                    center--;
                }
                else
                {
                    center = (n - 2) / 2;
                }

                if (i== center) // OR if (i==(n-2) / 2)
                {
                    Console.Write(new string('|', n));
                }
                else
                {
                    Console.Write(new string(' ', n));
                }

                Console.Write(new string('*', 1));
                Console.Write(new string('/', 2 * n - 2));
                Console.Write(new string('*', 1));
                Console.WriteLine();
            }

            Console.Write(new string('*', 2 * n));
            Console.Write(new string(' ', n));
            Console.WriteLine(new string('*', 2 * n));
        }
    }
}
