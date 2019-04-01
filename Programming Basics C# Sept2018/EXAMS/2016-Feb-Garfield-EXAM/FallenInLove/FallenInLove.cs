using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallenInLove
{
    class FallenInLove
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leaves = 1;
            int leaves2 = n;

            Console.Write("##");
            Console.Write(new string('.', 2 * n));
            Console.Write("##");
            Console.Write(new string('.', 2 * n));
            Console.WriteLine("##");

            for (int i = 1; i <= n - 1; i++)
            {
                
                Console.Write("#");
                Console.Write(new string('~', leaves));
                Console.Write("#");
                var dots = n * 2 - 2 * i;
                if (dots >= 0)
                {
                    Console.Write(new string('.', dots));
                    Console.Write("#");
                }
                var insideDots = 2 * i;
                if (dots >= 0)
                {
                    Console.Write(new string('.', insideDots));
                    Console.Write("#");

                }
                if (dots >= 0)
                {
                    Console.Write(new string('.', dots));
                    Console.Write("#");
                }
                Console.Write(new string('~', leaves));
                leaves++;
                Console.WriteLine("#");
            }
            for (int i = 1; i <= n; i++)
            {
                var dots = i*2 - 1;
                Console.Write(new string('.', dots));
                Console.Write("#");
                if (leaves2 >= 0)
                {
                    Console.Write(new string('~', leaves2));
                }
                Console.Write("#");
                var insideDots = 2 * n - (i*2 -2);
                if (insideDots >= 0)
                {
                    Console.Write(new string('.', insideDots));
                    Console.Write("#");
                }
                if (leaves >= 0)
                {
                    Console.Write(new string('~', leaves2));
                    leaves2--;
                }
                Console.Write("#");
                if (dots>= 0)
                {
                    Console.WriteLine(new string('.', dots));
                    dots--;
                }
            }
            Console.Write(new string('.', 2 * n+1));
            Console.Write("####");
            Console.WriteLine(new string('.', 2 * n + 1));
            for (int i = 1; i <= n; i++)
            {
                Console.Write(new string('.', 2 * n + 2));
                Console.Write("##");
                Console.WriteLine(new string('.', 2 * n + 2));
            }
        }
    }
}
