using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studio = 1;
            double suite = 1;
            double studioStay = studio * nights;
            double suiteStay = suite * nights;

            if (month == "May" || month == "October")
            {
                studio = 50;
                suite = 65;
                if (nights > 7 && nights <= 14)
                {
                    studio *= 0.95;
                    studioStay = studio * nights;
                    suiteStay = suite * nights;
                }
                else if (nights > 14)
                {
                    studio *= 0.7;
                    suite *= 0.9;
                    suiteStay = suite * nights;
                    studioStay = studio * nights;
                }
                else
                {
                    studioStay = studio * nights;
                    suiteStay = suite * nights;
                }
            }
            else if (month == "June" || month == "September")
            {
                studio = 75.20;
                suite = 68.70;
                if (nights > 14)
                {
                    studio *= 0.8;
                    suite *= 0.9;
                    suiteStay = suite * nights;
                    studioStay = studio * nights;
                }
                else
                {
                    studioStay = studio * nights;
                    suiteStay = suite * nights;
                }
            }
            else if (month == "July" || month == "August")
            {
                studio = 76;
                suite = 77;
                if (nights > 14)
                {
                    suite *= 0.9;
                    suiteStay = suite * nights;
                    studioStay = studio * nights;
                }
                else
                {
                    studioStay = studio * nights;
                    suiteStay = suite * nights;
                }
            }
            Console.WriteLine($"Apartment: {suiteStay:f2} lv.");
            Console.WriteLine($"Studio: {studioStay:f2} lv.");
        }
    }
}
