using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            double sum = 0;
            do
            {
                double credit = double.Parse(Console.ReadLine());
                count++;
                if (credit < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    Console.WriteLine($"Total: {sum:f2}");
                    return;
                }
                sum += credit;
                Console.WriteLine($"Increase: {credit:f2}");
                if (count == n)
                {
                    break;
                }
            } while (count <= n);
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
