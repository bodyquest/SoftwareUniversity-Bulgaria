using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> dict = new SortedDictionary<string, Dictionary<string, double>>();

            string input =Console.ReadLine();

            while (input != "Revision")
            {
                string[] info = input.Split(", ");
                string store = info[0];
                string product = info[1];
                double price = double.Parse(info[2]);

                if (!dict.ContainsKey(store))
                {
                    dict[store] = new Dictionary<string, double>();
                    if (!dict[store].ContainsKey(product))
                    {
                        dict[store][product] = price;
                    }
                    else
                    {
                        dict[store][product] = price;
                    }
                }
                else
                {
                    if (!dict[store].ContainsKey(product))
                    {
                        dict[store][product] = price;
                    }
                    else
                    {
                        dict[store][product] = price;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var store in dict.OrderBy(store => store.Key))
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var product in store.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
