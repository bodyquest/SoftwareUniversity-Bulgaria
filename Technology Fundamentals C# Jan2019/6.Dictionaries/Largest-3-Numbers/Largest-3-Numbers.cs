using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var sorted = array.OrderByDescending(n => n).ToArray();
            for (int i = 0; i < sorted.Length; i++)
            {
                Console.Write(sorted[i] + " ");
                if (i == 2)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
