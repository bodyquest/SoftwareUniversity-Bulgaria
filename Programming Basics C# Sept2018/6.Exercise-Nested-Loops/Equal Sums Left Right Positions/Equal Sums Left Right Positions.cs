using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums_Left_Right_Positions
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int leftSingles = 0;
            int rightSingles = 0;
            string numsS = String.Empty;
            int count = num1;

            for (int nums = num1; nums <= num2; nums++)
            {
                int leftSum = 0;
                int rightSum = 0;
                numsS = nums.ToString();
                for (int i = 1; i <= 2; i++)
                {
                    leftSingles = nums % 10;
                    leftSum += leftSingles;
                    nums /= 10;
                }
                nums /= 10;
                for (int i = 1; i <= 2; i++)
                {
                    rightSingles = nums % 10;
                    rightSum += rightSingles;
                    nums /= 10;
                }
                nums = num1++;
                if (leftSum == rightSum)
                {
                    if (count < num2)
                    {
                        Console.Write($"{count} ");
                    }
                    else if (count == num2)
                    {
                        Console.Write($"{count}");
                    }
                }
                else if (leftSum < rightSum)
                {

                    int newSum = 0;
                    int newLeft = (count / 100) % 10 + leftSum;
                    newSum = newSum + newLeft;
                    if (newSum == rightSum)
                    {
                        if (count < num2)
                        {
                            Console.Write($"{count} ");
                        }
                        else if (count == num2)
                        {
                            Console.Write($"{count}");
                        }
                    }
                }
                else if (leftSum > rightSum)
                {
                    int newSum = 0;
                    int newRight = (count / 100) %10 +rightSum;
                    newSum += newRight;

                    if (leftSum == newSum)
                    {
                        if (count < num2)
                        {
                            Console.Write($"{count} ");
                        }
                        else if (count == num2)
                        {
                            Console.Write($"{count}");
                        }
                    }
                }
                count++;
            }
            Console.WriteLine();
        }
    }
}
