using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Courier_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string serviceType = Console.ReadLine();
            double distance = double.Parse(Console.ReadLine());
            double priceKm = 0;
            double addPrice = 0;
            double price = priceKm * distance;

            if (serviceType.Equals ("standard"))
            {
                if (weight < 1)
                {
                    priceKm = 0.03;
                }
                else if (weight >=1 && weight <= 10)
                {
                    priceKm = 0.05;
                }
                else if (weight > 10 && weight <= 40)
                {
                    priceKm = 0.10;
                }
                else if (weight > 40 && weight <= 90)
                {
                    priceKm = 0.15;
                }
                else if (weight > 90 && weight <= 150)
                {
                    priceKm = 0.20;
                }
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg.would cost {priceKm* distance:f2} lv.");
            }
            else if (serviceType.Equals("express"))
            {
                if (weight < 1)
                {
                    priceKm = 0.03*1.8;
                }
                else if (weight >= 1 && weight <= 10)
                {
                    priceKm = 0.05;
                    addPrice = weight * priceKm * 0.4;
                }
                else if (weight > 10 && weight <= 40)
                {
                    priceKm = 0.10;
                    addPrice = weight * priceKm * 0.05;
                }
                else if (weight > 40 && weight <= 90)
                {
                    priceKm = 0.15;
                    addPrice = weight * priceKm * 0.02;
                }
                else if (weight > 90 && weight <= 150)
                {
                    priceKm = 0.20;
                    addPrice = weight * priceKm * 0.01;
                }
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg.would cost {distance* (price + addPrice):f2} lv.");
            }

        }
    }
}
