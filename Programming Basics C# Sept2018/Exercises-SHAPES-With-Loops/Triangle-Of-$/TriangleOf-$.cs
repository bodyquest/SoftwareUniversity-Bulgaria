using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleOf__
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (int row = 1; row <= n; row++)
            {
                //Console.Write("$");  Remove "=" from the condition bellow to use THIS LINE OF CODE
                for (int col = 1; col <= row; col++)
                    Console.Write(" $");
                Console.WriteLine();
            }
        }
    }
}
