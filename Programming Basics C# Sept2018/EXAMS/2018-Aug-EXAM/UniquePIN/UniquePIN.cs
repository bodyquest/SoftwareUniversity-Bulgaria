using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePIN
{
    class UniquePIN
    {
        static void Main(string[] args)
        {
            int num1UpperLimit = int.Parse(Console.ReadLine());
            int num2UpperLimit = int.Parse(Console.ReadLine());
            int num3UpperLimit = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num1UpperLimit; i++)
            {
                for (int prime = 2; prime <= num2UpperLimit; prime++)
                {
                    for (int k = 1; k <= num3UpperLimit; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0)
                        {
                            if (prime == 2 || prime == 3|| prime == 5 || prime == 7)
                            {
                                Console.WriteLine($"{i} {prime} {k}");
                            }
                        }
                    }
                }
            }

        }
    }
}
