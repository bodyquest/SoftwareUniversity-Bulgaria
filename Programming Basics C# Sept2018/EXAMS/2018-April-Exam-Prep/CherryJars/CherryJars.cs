using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryJars
{
    class CherryJars
    {
        static void Main(string[] args)
        {
            int compots = int.Parse(Console.ReadLine());
            int jam = int.Parse(Console.ReadLine());

            decimal priceCompots = (compots + 1) * 0.3m;
            decimal priceJams = (jam + 1) * 0.65m;
            decimal totalPriceComp = priceCompots *= 1.05m;
            decimal totalpriceJams = priceJams *= 1.10m;
            decimal totalPriceCherries = (totalPriceComp + totalpriceJams) * 3.20m;

            Console.WriteLine("{0:f2}", totalPriceCherries);

        }
    }
}
