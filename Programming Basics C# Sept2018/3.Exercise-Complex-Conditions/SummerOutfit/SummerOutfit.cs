using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerOutfit
{
    class SummerOutfit
    {
        static void Main(string[] args)
        {
            int temp = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();
            string shoes = String.Empty;
            string outfit = String.Empty;

            if (partOfDay == "Morning")
            {
                if (temp >= 10 && temp <= 18)
                {
                    shoes = "Sneakers"; outfit = "Sweatshirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Moccasins"; outfit = "Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Sandals"; outfit = "T-Shirt";
                }
            }
            else if (partOfDay == "Afternoon")
            {
                if (temp >= 10 && temp <= 18)
                {
                    shoes = "Moccasins"; outfit = "Shirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Sandals"; outfit = "T-Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Barefoot"; outfit = "Swim Suit";
                }
            }
            else if (partOfDay == "Evening")
            {
                if (temp >= 10 && temp <= 18)
                {
                    shoes = "Moccasins"; outfit = "Shirt";
                }
                else if (temp > 18 && temp <= 24)
                {
                    shoes = "Moccasins"; outfit = "Shirt";
                }
                else if (temp >= 25)
                {
                    shoes = "Moccasins"; outfit = "Shirt";
                }
            }
            Console.WriteLine($"It's {temp} degrees, get your {outfit} and {shoes}.");
        }
    }
}
