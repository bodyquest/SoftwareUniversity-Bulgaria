using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 1;
            if (n % 2 == 0)  // even n -> two stars on top; else -> one
            {
                stars++;
            }

            for (int i = 0; i < (n + 1) / 2; i++)   // drawing the roof
            {
                var spaces = (n - stars) / 2;
                Console.Write(new string('-', spaces));
                Console.Write(new string('*', stars));
                Console.Write(new string('-', spaces));
                stars = stars + 2;

                Console.WriteLine();
            }

            for (int i = 0; i < (n + 1) / 2; i++)   // drawing the base
            {
                var baseStars = n-2;
                var wall = 1;
                Console.Write(new string('|', wall));
                Console.Write(new string('*', baseStars));
                Console.Write(new string('|', wall));

                Console.WriteLine();
            }


        }
    }
}
