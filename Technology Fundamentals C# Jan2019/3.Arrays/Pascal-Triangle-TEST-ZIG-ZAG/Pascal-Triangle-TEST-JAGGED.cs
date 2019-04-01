using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle_TEST_JAGGED
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j;
            int n = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            int[][] arr = new int[n][];

            for (i = 0; i < n; i++)
            {
                arr[i] = new int[i+1];
                for (j = 0; j <= i; j++)
                {
                    if (j==0 || j == i)
                    {
                        arr[i][j] = 1;
                        Console.Write(arr[i][j]+ " ");
                    }
                    else
                    {
                        arr[i][j] = arr[i - 1][j - 1] + arr[i - 1][j];
                        Console.Write(arr[i][j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
