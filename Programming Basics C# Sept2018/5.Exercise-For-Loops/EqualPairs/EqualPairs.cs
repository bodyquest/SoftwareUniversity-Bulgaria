using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualPairs
{
    class EqualPairs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;
            int sum = 0;
            int sumPrev = 0;
            int maxDiff = 0;

            for (int i = 1; i <= n; i++)
            {
                num1 = int.Parse(Console.ReadLine());
                num2 = int.Parse(Console.ReadLine());
                sum = num1 + num2;
                if (i > 1)
                {
                    if (Math.Abs(sum - sumPrev) > maxDiff)
                    {
                        maxDiff = Math.Abs(sum - sumPrev);
                    }
                    //else if (sum - sumPrev == 0)
                    //{
                    //    continue;
                    //}
                }
                sumPrev = num1 + num2;
            }
            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
