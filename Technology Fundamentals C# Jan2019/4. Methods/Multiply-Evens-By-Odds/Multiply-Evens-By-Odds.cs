using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            //num = PrintNums(num, listEven, listOdd);

            Console.WriteLine($"{GetMultipleOfEvenAndOdds(num)}");

        }

       //private static int PrintNums(int num, List<int> listEven, List<int> listOdd)
       // {
       //     while (num != 0)
       //     {
       //         int digit = num % 10;
       //         if (digit < 0)
       //         {
       //             digit *= -1;
       //         }
       //         num /= 10;
       //         if (digit % 2 == 0)
       //         {
       //             listEven.Add(digit);
       //         }
       //         else if (digit % 2 != 0)
       //         {
       //             listOdd.Add(digit);
       //         }
       //     }
       //     listEven.Reverse();
       //     listOdd.Reverse();

       //     return num;
       // }

        private static int GetMultipleOfEvenAndOdds(int num)
        {
            return GetSumOfEvens(num) * GetSumOfOdds(num);
        }

        private static int GetSumOfEvens(int num)
        {
            int sum = 0;
            num = Math.Abs(num);
            while (num > 0)
            {
                int digit = num % 10;
                if (digit < 0)
                {
                    digit *= -1;
                }
                num /= 10;
                if (digit % 2 == 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }

        private static int GetSumOfOdds(int num)
        {
            int sum = 0;
            num = Math.Abs(num);
            while (num >0)
            {
                int digit = num % 10;
                if (digit < 0)
                {
                    digit *= -1;
                }
                num /= 10;
                if (digit % 2 != 0)
                {
                    sum += digit;
                }
            }

            return sum;
        }
    }
}
