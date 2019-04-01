using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newHouse
{
    class newHouse
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 1;

            if (flower == "Roses")
            {
                price = 5;
                if (count > 80)
                {
                    price = price * 0.9;
                }
            }
            else if (flower == "Dahlias")
            {
                price = 3.80;
                if (count > 90)
                {
                    price = price * 0.85;
                }
            }
            else if (flower == "Tulips")
            {
                price = 2.80;
                if (count > 80)
                {
                    price = price * 0.85;
                }
            }
            else if (flower == "Narcissus")
            {
                price = 3;
                if (count < 120)
                {
                    price = price * 1.15;
                }
            }
            else if (flower == "Gladiolus")
            {
                price = 2.50;
                if (count < 80)
                {
                    price = price * 1.2;
                }
            }
            double moneyLeft = budget - (price * count);
            double moneyNeeded = (price * count) - budget;
            if (budget >= (count*price))
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {flower} and {moneyLeft:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {moneyNeeded:f2} leva more.");
            }
        }
    }
}
