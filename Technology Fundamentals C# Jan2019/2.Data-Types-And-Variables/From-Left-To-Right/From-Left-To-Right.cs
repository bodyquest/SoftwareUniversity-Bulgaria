using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace From_Left_To_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long sumLeft = 0;
            long sumRight = 0;
            for (int i = 0; i < n; i++)
            {
                var num = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                long left = num[0];
                long right = num[1];

                if (left > right)
                {
                    while (left != 0)
                    {
                        long digit = left % 10;
                        sumLeft += digit;
                        left /= 10;
                    }

                    Console.WriteLine(Math.Abs(sumLeft));
                    sumLeft = 0;
                }
                else
                {
                    while (right != 0)
                    {
                        long digit = right % 10;
                        sumRight += digit;
                        right /= 10;
                    }

                    Console.WriteLine(Math.Abs(sumRight));
                    sumRight = 0;
                }
            }
        }
    }
}
