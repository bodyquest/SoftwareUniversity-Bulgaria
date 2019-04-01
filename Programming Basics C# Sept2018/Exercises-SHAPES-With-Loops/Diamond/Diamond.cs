using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond
{
    class Diamond
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var outsideDash = (n - 1) / 2;

            
            for (int i = 1; i <= (n - 1) / 2; i++)
            {
                
                Console.Write(new string('-', outsideDash));
                Console.Write("*");
                var inside = n - 2 * outsideDash - 2;
                if (inside >= 0)
                {
                    Console.Write(new string('-', inside));
                    Console.Write("*");
                }
                
                Console.Write(new string('-', outsideDash));
                outsideDash--;
                Console.WriteLine();
            }
            for (int i = 1; i <= (n + 1) / 2; i++)
            {
                Console.Write(new string('-', outsideDash));
                Console.Write("*");
                var inside = n - 2 * outsideDash - 2;
                if (inside >= 0)
                {
                    Console.Write(new string('-', inside));
                    Console.Write("*");
                }

                Console.Write(new string('-', outsideDash));
                outsideDash++;

                Console.WriteLine();
            }


        }
    }
}


