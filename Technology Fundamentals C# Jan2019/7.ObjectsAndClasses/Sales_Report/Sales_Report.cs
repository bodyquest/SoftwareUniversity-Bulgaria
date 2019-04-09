using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Report
{
    class Sales_Report
    {
        class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }

        class SalesByCity
        {
            public string Town { get; set; }
            public decimal Sales { get; set; }
        }

        static void Main(string[] args)
        {
            var products = ReadSales(); //read all products
            //var salesByCity = CalcSalesByCity(products);
            //foreach (var s in salesByCity)
            //{
            //    Console.WriteLine($"{s.Town} -> {s.Sales}");
            //}
        }

        private static Sale[] ReadSales()
        {
            var count = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[count];
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split();
                sales[i] = new Sale()
                {
                    Town = input[0],
                    Product = input[1],
                    Price = decimal.Parse(input[2]),
                    Quantity = decimal.Parse(input[3]),
                };

                return sales;
            }
        }
    }
}
