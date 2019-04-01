using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exact_Sum_Of_Real_Numbers
{
    class Program
    {

        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            decimal sum = 0m;
            for (int i = 0; i < num; i++)
            {
                decimal n = decimal.Parse(Console.ReadLine());
                sum += n;
            }

            Console.WriteLine(sum);
        }
    }
}
