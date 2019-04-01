using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class OddEvenSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var oddSum = 0;
            var evenSum = 0;
            for (int i = 0; i < n; i++)
            {
                var x = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += x;
                }
                else
                {
                    oddSum += x;
                }
            }
            //Console.WriteLine("Odd sum = {0}", oddSum);
            //Console.WriteLine("Even sum = {0}", evenSum);
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes, sum = {0}", evenSum);
            }
            else
            {
                var diff = Math.Abs(evenSum - oddSum);
                Console.WriteLine("No, diff = {0}", diff);
            }
        }
    }
}
