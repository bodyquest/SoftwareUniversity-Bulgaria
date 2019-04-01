using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garfield
{
    class Garfield
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            decimal USDforex = decimal.Parse(Console.ReadLine());

            decimal pizzaPrice = decimal.Parse(Console.ReadLine());
            decimal lasagnaPrice = decimal.Parse(Console.ReadLine());
            decimal sandwichPrice = decimal.Parse(Console.ReadLine());
            decimal pizzaQty = decimal.Parse(Console.ReadLine());
            decimal lasagnaQty = decimal.Parse(Console.ReadLine());
            decimal sandwichQty = decimal.Parse(Console.ReadLine());

            decimal toSpend = pizzaPrice * pizzaQty + lasagnaPrice * lasagnaQty + sandwichPrice * sandwichQty;
            decimal toSpendUSD = toSpend / USDforex;

            if (toSpendUSD <= money)
            {
                Console.WriteLine($"Garfield is well fed, John is awesome. Money left: ${money - toSpendUSD:f2}.");
            }
            else
            {
                Console.WriteLine($"Garfield is hungry. John is a badass. Money needed: ${toSpendUSD - money:f2}.");
            }


        }
    }
}
