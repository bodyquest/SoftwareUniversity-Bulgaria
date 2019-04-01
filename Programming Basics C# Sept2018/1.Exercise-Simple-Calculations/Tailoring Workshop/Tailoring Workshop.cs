using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            //covers - rectangular and 30cm from each side // cost 7 USD/m2
            //care - square = tableLength/2  // cost 9 USD/m2
            // they are same qty always
            //each QUOTATION has info about QTY & SIZE of tables
            //CALCULATE QUOTATION PRICE in USD and BGN @1.85 USD/BGN
            //INPUT : QTY; LENGHT; WIDTH
            //OUTPUT : USD price; BGN Price

            double qty = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double coverArea = (length + 2 * 0.3) * (width + 2 * 0.3) * qty;
            double coverCost = coverArea * 7;
            double careArea = length/2  * length / 2 * qty;
            double careCost = careArea * 9;

            double quotationCost = (coverCost + careCost);

            Console.WriteLine($"{quotationCost:F2}" + " USD");
            Console.WriteLine($"{quotationCost * 1.85:F2}" + " BGN");

        }
    }
}
