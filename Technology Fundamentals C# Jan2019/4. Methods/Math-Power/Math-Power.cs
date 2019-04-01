using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(GetPowerOfNum(num, power));
        }

        private static double GetPowerOfNum(double num, int power)
        {
            double result = num;
            for (int i = 1; i < power; i++)
            {
                result *= num;
            }
            return result;
        }
    }
}