using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<long> fibo = new Stack<long>();
            int n = int.Parse(Console.ReadLine());

            long f0 = 0;
            long f1 = 1;
            fibo.Push(f0);
            fibo.Push(f1);

            for (int i = 0; i < n-1; i++)
            {
                f0 = fibo.Pop();
                f1 = fibo.Peek();

                fibo.Push(f0);
                fibo.Push(f0 + f1);
            }
        }
    }
}
