using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintTriangleOfNums(n);
        }

        private static void PrintTriangleOfNums(int n)
        {
            for (int rows = 1; rows <= n; rows++)
            {
                for (int col = 0; col < rows; col++)
                {
                    Console.Write(1 + col + " ");
                }

                Console.WriteLine();
            }

            for (int subRows = 0; subRows < n - 1; subRows++)
            {
                for (int col = 0; col < n - subRows - 1; col++)
                {
                    Console.Write(1 + col + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
