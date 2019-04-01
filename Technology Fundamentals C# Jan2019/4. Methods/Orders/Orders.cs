using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    class Orders
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int qty = int.Parse(Console.ReadLine());
            GetTotalPrice(product, qty);
        }

        private static void GetTotalPrice(string product, int qty)
        {
            switch (product)
            {
                case "coffee": Console.WriteLine($"{1.5 * qty:f2}"); break;
                case "water": Console.WriteLine($"{1 * qty:f2}"); break;
                case "coke": Console.WriteLine($"{1.4 * qty:f2}"); break;
                case "snacks": Console.WriteLine($"{2.0 * qty:f2}"); break;
                default:
                    break;
            }
        }
    }
}
