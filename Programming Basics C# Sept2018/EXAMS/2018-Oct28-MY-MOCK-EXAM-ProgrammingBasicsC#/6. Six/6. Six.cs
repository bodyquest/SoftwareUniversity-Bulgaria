using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Six
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int one = num % 10;
            num /= 10;
            int two = num % 10;
            num /= 10;
            int three = num %10;

            for (int first = 1; first <= one; first++)
            {
                for (int second = 1; second <= two; second++)
                {
                    for (int third = 1; third <= three; third++)
                    {
                        if (one > 0 && two > 0 && three > 0)
                        {
                            Console.WriteLine($"{first} * {second} * {third} = {first*second*third};");
                        }
                    }
                }
            }
        }
    }
}
