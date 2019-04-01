using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursive_Fino
{
    class Program
    {
       static int x = 5;
       static int n = 3;
        static void Main(string[] args)
        {
            


        }

        static int FibonacciIterative(int x)
        {
            int fn1 = 1;
            int fn2 = 1;
            for (int i = 3; i <= n; i++)
            {
                int fn_temp = fn2; //to switch later
                fn1 = fn2 + fn1;
                fn2 = fn_temp; // switch here
            }

            return fn1;
        }

        static int FibonacciIterative(int n)
        {

            return 0;
        }
    }
}
