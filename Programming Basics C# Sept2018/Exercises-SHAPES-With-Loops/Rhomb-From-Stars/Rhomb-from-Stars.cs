using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhomb_from_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 0;
            var spaces = 0;

            for (int row = 1; row <= n; row++)
            {
                for (spaces = 0; spaces < n-row; spaces++)
                    Console.Write(" ");
                Console.Write("*");

                for (stars = 0; stars < row - 1; stars++)
                    Console.Write(" *");
                Console.WriteLine();
            }
            for (int row = 1; row <= n-1; row++)
            {
                for (spaces = 0; spaces < row; spaces++)
                    Console.Write(" ");
                Console.Write("*");

                for (stars = 1; stars < n-row; stars++)
                    Console.Write(" *");
                Console.WriteLine();
            }
            Console.WriteLine();

            //    for (int i = 0; i < stars; i++)
            //        Console.Write("*");
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //stars--;
            //spaces++;

        }
    }
}
