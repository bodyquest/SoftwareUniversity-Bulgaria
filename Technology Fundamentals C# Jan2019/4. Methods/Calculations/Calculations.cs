using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add": AddNums(a, b); break;
                case "subtract": SubtractNums(a, b); break;
                case "divide": DivideNums(a, b); break;
                case "multiply": MultiplyNums(a, b); break;
                default:
                    break;
            }

        }

        private static void AddNums(int a, int b)
        {
            Console.WriteLine(a+b);
        }

        private static void SubtractNums(int a, int b)
        {
            Console.WriteLine(a - b);

        }

        private static void MultiplyNums(int a, int b)
        {
            Console.WriteLine(a * b);

        }

        private static void DivideNums(int a, int b)
        {
            Console.WriteLine(a / b);

        }
    }
}
