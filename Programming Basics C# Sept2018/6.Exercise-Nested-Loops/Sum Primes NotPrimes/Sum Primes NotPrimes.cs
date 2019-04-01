using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Primes_NotPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumPrimes = 0;
            int sumNonPrimes = 0;
            string input = String.Empty;


            while (input != "stop")
            {
                input = Console.ReadLine();
                int.TryParse(input, out int num);
                bool prime = true;

                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        prime = false;
                        break;
                    }
                }
                if (prime && num != 1)
                {
                    sumPrimes += num;
                }
                else
                {
                    sumNonPrimes += num;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimes}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimes}");
        }
    }
}
