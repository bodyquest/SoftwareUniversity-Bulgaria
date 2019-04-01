using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int row = 1; row <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    count++;
                    if (col<row)
                    {
                        Console.Write($"{count} ");
                    }
                    else if(col==row)
                    {
                        Console.Write($"{count}");
                    }
                    
                    if (count == n)
                    {
                        Console.WriteLine();
                        return;
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
