using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int division = 0;
            do
            {
                if (num % 10 == 0)
                {
                    division = 10;
                    break;
                }
                else if (num % 7 == 0)
                {
                    division = 7;
                    break;
                }
                else if (num % 6 == 0)
                {
                    division = 6;
                    break;
                }
                else if (num % 3 == 0)
                {
                    division = 3;
                    break;
                }
                else if (num % 2 == 0)
                {
                    division = 2;
                    break;
                }
            } while (division != 0);

            if (division == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {division}");
            }
        }
    }
}
