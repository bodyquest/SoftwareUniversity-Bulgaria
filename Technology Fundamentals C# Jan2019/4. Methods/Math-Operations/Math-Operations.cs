using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            CalculateResult(num1, @operator, num2);
        }

        private static void CalculateResult(int num1, char @operator, int num2)
        {
            switch (@operator)
            {
                case '*': Console.WriteLine($"{num1 * num2}"); break;
                case '/': Console.WriteLine($"{num1 / num2}"); break;
                case '-': Console.WriteLine($"{num1 - num2}"); break;
                case '+': Console.WriteLine($"{num1 + num2}"); break;
                default:
                    break;
            }
        }
    }
}
