using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fibo_Memoization
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var memo = new decimal[n+1];
            Console.WriteLine(Fibonacci(n, memo));
        }

        static decimal Fibonacci (int n, decimal[] memo)
        {
            if ((n == 1) || (n == 2))
            {
                return 1;
            }
            else
            {
                if (memo[n] == 0)
                {
                    memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
                }
                return memo[n];
            }

        }

        ////Divide and Conquer method- SLOW
        //static decimal Fibonacci (int n)
        //{
        //    if (n == 0)
        //    {
        //        return 0;
        //    }
        //    if (n == 1)
        //    {
        //        return 1;
        //    }
        //    return Fibonacci(n - 1) + Fibonacci(n - 2);
        //}
    }
}
