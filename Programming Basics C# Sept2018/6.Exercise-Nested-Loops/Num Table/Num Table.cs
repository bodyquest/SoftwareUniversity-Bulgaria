using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int col = row; col <= n; col++)
                {
                    Console.Write(col+ " ");
                }
                if (row >1)
                {
                    for (int rev = n - 1; rev >= n - row + 1; rev--)
                    {
                        if (rev > n - row + 1)
                        {
                            Console.Write(rev + " ");
                        }
                        else if(rev == n - row + 1)
                        {
                            Console.Write(rev);
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
