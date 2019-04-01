using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Beer_and_Chips
{
    class Program
    {
        static void Main(string[] args)
        {
            string fanName = Console.ReadLine();
            decimal budget = decimal.Parse(Console.ReadLine());
            int beerBottleCount = int.Parse(Console.ReadLine());
            int chipsPackets = int.Parse(Console.ReadLine());

            decimal beerPrice = 1.2m;
            decimal beerCost = beerPrice * beerBottleCount;
            decimal chipsPrice = beerBottleCount * beerPrice;
            decimal chipsCost = Math.Ceiling(0.45m *(chipsPackets * chipsPrice));

            decimal bill = beerCost + chipsCost;

            if (budget >= bill)
            {
                Console.WriteLine($"{fanName} bought a snack and has {budget - bill:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"{fanName} needs {bill - budget:f2} more leva!");
            }


        }
    }
}
