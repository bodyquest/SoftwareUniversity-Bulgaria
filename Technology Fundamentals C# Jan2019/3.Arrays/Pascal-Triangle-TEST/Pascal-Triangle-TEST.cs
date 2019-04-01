using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle_TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            int[][] arr = new int[n][];

            for (int rows = 0; rows < n; rows++)
            {
                int item = 1;
                for (int col = 0; col <= rows; col++)
                {
                    Console.Write(item + " ");
                    item = item *  (rows - col) / (col + 1);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
