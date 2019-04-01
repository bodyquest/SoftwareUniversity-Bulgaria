using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 7; i++)
            {
                Console.Write("*");
                for (int col = i; col < 7; col++)
                    Console.Write(" *");
                Console.WriteLine();
            }
        }
    }
}
