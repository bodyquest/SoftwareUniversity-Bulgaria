using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Stadium
{
    class Program
    {
        static void Main(string[] args)
        {
            int sectorsQty = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            decimal ticketPrice = decimal.Parse(Console.ReadLine());

            decimal totalRevenue = capacity * ticketPrice;
            decimal revenueSector = totalRevenue / sectorsQty;

            decimal charitySum = (totalRevenue - 0.75m * revenueSector)/ 8;

            Console.WriteLine($"Total income - {totalRevenue:f2} BGN");
            Console.WriteLine($"Money for charity - {charitySum:f2} BGN");

        }
    }
}
