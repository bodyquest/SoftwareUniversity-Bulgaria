using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Wire_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double pricePerMeter = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());

            double lengthTotal = lenght * 2 + width * 2;
            double priceToBuy = lengthTotal * pricePerMeter;
            double area = lengthTotal * height;
            double totalWeight = area * weight;


            Console.WriteLine($"{lengthTotal:f2}");
            Console.WriteLine($"{priceToBuy:f2}");
            Console.WriteLine($"{totalWeight:f3}");

        }
    }
}
