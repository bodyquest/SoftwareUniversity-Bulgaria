using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_And_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int sumOfTwoNumbers = SumFirstAndSecondNumber(first, second);
            Console.WriteLine(SubtractTwoIntegers(third, sumOfTwoNumbers));
        }

        private static int SubtractTwoIntegers(int third, int sumOfTwoNumbers)
        {
            return sumOfTwoNumbers - third;
        }

        private static int SumFirstAndSecondNumber(int first, int second)
        {
            return first + second;
        }
    }
}
