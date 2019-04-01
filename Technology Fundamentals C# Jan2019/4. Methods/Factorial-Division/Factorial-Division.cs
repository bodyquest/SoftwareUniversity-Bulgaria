using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());

            decimal firstFact = GetFactorial(one);
            decimal secondFact = GetFactorial(two);

            decimal final = firstFact / secondFact;
            Console.WriteLine($"{final:f2}");
        }

        private static decimal GetFactorial(decimal num)
        {
            decimal factorial = 1;
            for (decimal i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
