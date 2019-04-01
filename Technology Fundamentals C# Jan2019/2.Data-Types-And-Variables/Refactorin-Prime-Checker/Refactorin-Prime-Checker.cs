using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorin_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int prime = 2; prime <= input; prime++)
            {
                bool isPrime = true;
                for (int p = 2; p < prime; p++)
                {
                    if (prime % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{prime} -> {isPrime.ToString().ToLower()}");
            }

        }
    }
}
