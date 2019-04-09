using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab
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

    class Lab
    {
        static void Main()
        {
            var sales = ReadSales();
            var salesByCity = CalcSalesByCity(sales);
            foreach (var s in salesByCity.OrderBy(entry=>entry.Town))
            {
                Console.WriteLine($"{s.Town} -> {s.Sales:f2}");
            }
        }

        private static List<SalesByCity> CalcSalesByCity(Sale[] sales)
        {
            var salesByCity = new Dictionary<string, decimal>();
            foreach (var s in sales)
            {
                if (!salesByCity.ContainsKey(s.Town))
                {
                    salesByCity[s.Town] = 0;
                    salesByCity[s.Town] += s.Quantity * s.Price;
                }
            }
            var salesList = salesByCity.Select(s => new SalesByCity()
            {
                Town = s.Key,
                Sales = s.Value
            }).ToList();
            return salesList;
        }

        private static Sale[] ReadSales()
        {
            var count = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[count];
            for (int i = 0; i < count; i++)
            {
                var inputLine = Console.ReadLine().Split(' ').ToArray();
                sales[i] = new Sale()
                {
                    Town = inputLine[0],
                    Product = inputLine[1],
                    Price = decimal.Parse(inputLine[2]),
                    Quantity = decimal.Parse(inputLine[3]),
                };
            }
            return sales;
        }
    }
}
