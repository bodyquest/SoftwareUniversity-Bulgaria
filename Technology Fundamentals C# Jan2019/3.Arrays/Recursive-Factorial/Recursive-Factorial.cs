using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double factorial = FindFactorial(number);
            Console.WriteLine($"Factorial of {number.ToString()} is: {factorial}");

        }

        //without recursion
        //public static double FindFactorial (int number)
        //{
        //    if (number == 0)
        //    {
        //        return 1;
        //    }
        //    double factorial = 1;

        //    for (int i = number; i >= 1; i--)
        //    {
        //        factorial = factorial * i;
        //    }
        //    return factorial;
        //}

        // RECURSION
        public static double FindFactorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            
            return number * FindFactorial(number -1);
        }
    }
}
