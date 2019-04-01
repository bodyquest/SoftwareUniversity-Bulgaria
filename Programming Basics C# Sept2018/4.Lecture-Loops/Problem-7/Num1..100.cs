using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num1to100
{
    class Program
    {
        static void Main(string[] args)
        {
            //num 1..100

            Console.Write("Enter a number in the range [1...100]: ");
            int num = int.Parse(Console.ReadLine());
            while (1 > num || num > 100)
            {
                Console.WriteLine("Invalid number!");
                Console.Write("Enter a number in the range [1...100]: ");
                num = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The number is: {num}");
        }
    }
}
