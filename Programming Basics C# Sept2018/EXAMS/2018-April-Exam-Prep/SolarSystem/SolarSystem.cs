using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem
{
    class SolarSystem
    {
        static void Main(string[] args)
        {
            string planetName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            double distance = 0;
            int maxdays = 0;

            if (planetName == "Mercury")
            {
                distance = 0.61;
                maxdays = 7;
            }
            else if (planetName == "Venus")
            {
                distance = 0.28;
                maxdays = 14;
            }
            else if (planetName == "Mars")
            {
                distance = 0.52;
                maxdays = 20;
            }
            else if (planetName == "Jupiter")
            {
                distance = 4.2;
                maxdays = 5;
            }
            else if (planetName == "Saturn")
            {
                distance = 8.52;
                maxdays = 3;
            }
            else if (planetName == "Uranus")
            {
                distance = 18.21;
                maxdays = 3;
            }
            else if (planetName == "Neptune")
            {
                distance = 29.09;
                maxdays = 2;
            }
            if (planetName == "Mercury" || planetName == "Venus" || planetName == "Mars" || planetName == "Jupiter" || planetName == "Saturn" || planetName == "Uranus" || planetName == "Neptune")
            {
                if (days > maxdays)
                {
                    Console.WriteLine("Invalid number of days!");
                }
                else
                {
                    Console.WriteLine($"Distance: {distance*2:f2}");
                    Console.WriteLine($"Total number of days: {2*226*distance + days:f2}");
                }
            }
            else
            {
                Console.WriteLine("Invalid planet name!");
            }
            
        }
    }
}
