using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int itemsCount = int.Parse(Console.ReadLine());

            double bill = 0;

            for (int items = 1; items <= itemsCount; items++)
            {
                string item = Console.ReadLine();
                switch (item)
                {
                    case "hoodie": bill += 30; break;
                    case "keychain": bill += 4; break;
                    case "T-shirt": bill += 20; break;
                    case "flag": bill += 15; break;
                    case "sticker": bill += 1; break;
                }
            }
            if (budget >= bill)
            {
                Console.WriteLine($"You bought {itemsCount} items and left with {budget-bill} lv.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {bill - budget} more lv.");
            }

        }
    }
}
