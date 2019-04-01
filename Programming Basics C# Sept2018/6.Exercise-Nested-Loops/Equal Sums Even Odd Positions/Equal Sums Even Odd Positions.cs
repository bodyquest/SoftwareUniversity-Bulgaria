using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Even_Odd_Positions
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            
            int oddSingles = 0;
            int evenSingles = 0;
            string numsS = String.Empty;

            for (int nums = num1; nums <= num2; nums++)
            {
                int oddSum = 0;
                int evenSum = 0;
                numsS = nums.ToString();
                for (int i = 1; i <= 3; i++)
                {
                    oddSingles = nums % 10;
                    oddSum += oddSingles;
                    nums /= 10;
                    evenSingles = nums % 10;
                    evenSum += evenSingles;
                    nums /= 10;
                }
                nums = num1++;
                if (oddSum == evenSum)
                {
                    if (nums -1 < num2)
                    {
                        Console.Write($"{nums} ");
                    }
                    else if (nums == num2)
                    {
                        Console.Write($"{nums}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
