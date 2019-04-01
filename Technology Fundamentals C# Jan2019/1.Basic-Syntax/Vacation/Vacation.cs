using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string day = Console.ReadLine();
            double price = 0.0;
            double total = 0.0;

            if (type == "Students")
            {
                switch (day)
                {
                    case "Friday": price = 8.45; break;
                    case "Saturday": price = 9.80; break;
                    case "Sunday": price = 10.46; break;
                    default:
                        break;
                }

                if (num >= 30)
                {
                    total = (num * price) - (num * price)* 0.15;
                }
                else
                {
                    total = num * price;
                }

            }

            else if (type == "Business")
            {
                switch (day)
                {
                    case "Friday": price = 10.90; break;
                    case "Saturday": price = 15.60; break;
                    case "Sunday": price = 16; break;
                    default:
                        break;
                }

                if (num >= 100)
                {
                    total = (num-10) * price;
                }
                else
                {
                    total = num * price;
                }
            }

            else if (type == "Regular")
            {
                switch (day)
                {
                    case "Friday": price = 15; break;
                    case "Saturday": price = 20; break;
                    case "Sunday": price = 22.50; break;
                    default:
                        break;
                }

                if (num >= 10 && num <= 20)
                {
                    total = (num * price) - (num * price) * 0.05;
                }
                else
                {
                    total = num * price;
                }
            }

            Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
