using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            // 
            // 
            // 

            double whiskeyPrice = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakiya = double.Parse(Console.ReadLine());
            double whiskey = double.Parse(Console.ReadLine());

            double rakiyaPrice = whiskeyPrice / 2;
            double winePrice = rakiyaPrice - ( 0.4 * rakiyaPrice);
            double beerPrice = rakiyaPrice - (0.8 * rakiyaPrice);

            double sumRakiya = rakiya * rakiyaPrice;
            double sumWine = wine * winePrice;
            double sumBeer = beer * beerPrice;
            double sumWhiskey = whiskey * whiskeyPrice;
            double total = sumRakiya + sumWine + sumBeer + sumWhiskey;

            Console.WriteLine($"{total:F2}");
        }
    }
}
