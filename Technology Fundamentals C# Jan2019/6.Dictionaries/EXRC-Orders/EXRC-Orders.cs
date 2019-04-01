using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Orders
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> productQty = new Dictionary<string, int>();
            Dictionary<string, decimal> productPrice = new Dictionary<string, decimal>();

            while (true)
            {

                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input.Split();
                string product = tokens[0];
                decimal price = decimal.Parse(tokens[1]);
                int qty = int.Parse(tokens[2]);

                if (productPrice.ContainsKey(product) == false)
                {
                    //productPrice[product] = price; // if we repeat this in "if/else", put them outside!
                    productQty[product] = qty;
                }
                else
                {
                    //productPrice[product] = price;
                    productQty[product] += qty;
                }
                productPrice[product] = price;
            }

            foreach (var kvp in productQty)
            {
                string product = kvp.Key;
                int qty = kvp.Value;
                decimal price = productPrice[product];

                decimal result = qty * price;

                Console.WriteLine($"{product} -> {result:f2}");
            }
        }
    }
}
