using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.One
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal foodMoney = decimal.Parse(Console.ReadLine());
            decimal souvenirs = decimal.Parse(Console.ReadLine());
            decimal hotel = decimal.Parse(Console.ReadLine());

            decimal dayOne = hotel * 0.9m;
            decimal dayTwo = hotel * 0.85m;
            decimal dayThree = hotel * 0.80m;
            decimal fuelCost = 1.85m * 7m * 4.2m;
            decimal foodAndSouvenirs = 3m * foodMoney + 3m * souvenirs;

            Console.WriteLine($"Money needed: {fuelCost + dayOne + dayTwo + dayThree + foodAndSouvenirs:f2}");
        }
    }
}
