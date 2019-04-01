using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stars = 0;
            var spaces = 0;

            for (int row = 0; row <= n; row++)
            {
                for (spaces = 0; spaces < n - row; spaces++)
                    Console.Write(" ");
                
                for (stars = 0; stars <= row - 1; stars++)
                    Console.Write("*");
                Console.Write(" | ");

                for (stars = 0; stars <= row - 1; stars++)
                    Console.Write("*");

                for (spaces = 0; spaces < n - row; spaces++)
                    Console.Write(" ");
                Console.WriteLine();
            }
            

        }
    }
}
