using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideWithoutRemainder
{
    class DivideWithoutRemainder
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            int divisible2 = 0;
            int divisible3 = 0;
            int divisible4 = 0;

            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num % 2 ==0)
                {
                    divisible2++;
                }
                if (num % 3 == 0)
                {
                    divisible3++;
                }
                if (num % 4 == 0)
                {
                    divisible4++;
                }
            }
            Console.WriteLine($"{(double)divisible2 / n * 100:f2}%");
            Console.WriteLine($"{(double)divisible3 / n * 100:f2}%");
            Console.WriteLine($"{(double)divisible4 / n * 100:f2}%");
        }
    }
}
