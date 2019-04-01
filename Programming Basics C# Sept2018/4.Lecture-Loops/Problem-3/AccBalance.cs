using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            decimal sum = 0;
            do
            {
                decimal credit = decimal.Parse(Console.ReadLine());
                sum += credit;
                if (credit < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {sum:f2}");
                    return;
                }
            } while (count <= n);
            Console.WriteLine($"Increase: {sum:f2}");
        }
    }
}
