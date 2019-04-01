using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                Console.Write("*");
            
                for (int col = 2; col <= n; col++)
                    Console.Write(" *");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
