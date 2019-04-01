using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingTime
{
    class ShoppingTime
    {
        static void Main(string[] args)
        {
            int lunchTime = int.Parse(Console.ReadLine());
            double pricePeripherals = double.Parse(Console.ReadLine());
            double priceProgram = double.Parse(Console.ReadLine());
            double priceFrappe = double.Parse(Console.ReadLine());

            int timePeripherals = 3 * 2;
            int timeProgram = 2 * 2;

            Console.WriteLine($"{(3 * pricePeripherals) + (2 * priceProgram) + priceFrappe:f2}");
            Console.WriteLine(lunchTime - 5 - timePeripherals - timeProgram);
        }
    }
}
