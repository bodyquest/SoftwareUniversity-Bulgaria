using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingBoat
{
    class FishingBoat
    {
        static void Main(string[] args)
        {
            // От конзолата се четат точно три реда.

            //•	Бюджет на групата – цяло число в интервала[1…8000]
            //•	Сезон –  текст: "Spring", "Summer", "Autumn", "Winter"
            //•	Брой рибари – цяло число в интервала[4…18]
            //Изход
            //Да се отпечата на конзолата един ред:
            //•	Ако бюджетът е достатъчен:
            //"Yes! You have {останалите пари} leva left."
            //•	Ако бюджетът НЕ Е достатъчен:
            //            "Not enough money! You need {сумата, която не достига} leva."
            //Сумите трябва да са форматирани с точност до два знака след десетичната запетая.

            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());
            double rent = 1;

            if (season == "Spring")
            {
                rent = 3000;
                if (fishermen % 2 == 0)
                {
                    rent = 0.95 * rent;
                }
                if (fishermen <= 6)
                {
                    rent = rent * (1 - 0.1);
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    rent = rent * (1 - 0.15);
                }
                else if (fishermen >= 12)
                {
                    rent = rent * (1 - 0.25);
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                rent = 4200;
                if (fishermen % 2 == 0 && season == "Summer")
                {
                    rent = 0.95 * rent;
                }
                if (fishermen <= 6)
                {
                    rent = rent * (1 - 0.1);
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    rent = rent * (1 - 0.15);
                }
                else if (fishermen >= 12)
                {
                    rent = rent * (1 - 0.25);
                }
            }
            else if (season == "Winter")
            {
                rent = 2600;
                if (fishermen % 2 == 0)
                {
                    rent = 0.95 * rent;
                }
                if (fishermen <= 6)
                {
                    rent = rent * (1 - 0.1);
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    rent = rent * (1 - 0.15);
                }
                else if (fishermen >= 12)
                {
                    rent = rent * (1 - 0.25);
                }
            }
            if (budget >= rent)
            {
                Console.WriteLine($"Yes! You have {budget - rent:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rent - budget:f2} leva.");
            }

            //decimal budget = decimal.Parse(Console.ReadLine());
            //string season = Console.ReadLine();
            //int fishermanCount = int.Parse(Console.ReadLine());
            //decimal price = 0;
            //switch (season)
            //{
            //    case "Spring": price = 3000.00m; break;
            //    case "Summer": price = 4200.00m; break;
            //    case "Autumn": price = 4200.00m; break;
            //    case "Winter": price = 2600.00m; break;
            //}

            //price *= fishermanCount <= 6 ? 0.9m : fishermanCount <= 11 ? 0.85m : 0.75m;
            //price *= (fishermanCount % 2 == 0 && season != "Autumn") ? 0.95m : 1;

            //Console.WriteLine(budget >= price ?
            //    $"Yes! You have {budget - price:F2} leva left." :
            //    $"Not enough money! You need {price - budget:F2} leva.");
        }
    }
}
