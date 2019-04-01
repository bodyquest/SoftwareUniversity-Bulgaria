using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumEqualToSumOfRest
{
    class NumEqualToSumOfRest
    {
        static void Main(string[] args)
        {
            //Да се напише програма,
            //която чете n-на брой цели числа, въведени от потребителя, и проверява дали сред тях съществува число,
            //което е равно на сумата на всички останали.
            //Ако има такъв елемент, печата "Yes", "Sum = " + неговата стойност; иначе печата "No", "Diff = " + разликата между най-големия елемент и сумата на останалите(по абсолютна стойност).

            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            int num = 0;
            int max = int.MinValue;

            for (int nums = 1; nums <= n; nums++)
            {
                num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }
            }
            double diff = Math.Abs(max - (sum - max));
            if (max == sum/2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine($"Sum = {max}");
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine($"Diff = {diff}");
            }
        }
    }
}
