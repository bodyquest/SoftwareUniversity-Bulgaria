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
            string planet = Console.ReadLine();
            int daysOnPlanet = int.Parse(Console.ReadLine());
            double distance = 1;
            int AU = 226;

            if (planet == "Mercury")
            {
                if (daysOnPlanet >=1 && daysOnPlanet <= 7)
                {
                    distance = 0.61 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Venus")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 14)
                {
                    distance = 0.28 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Mars")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 20)
                {
                    distance = 0.52 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Jupiter")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 5)
                {
                    distance = 4.2 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Saturn")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 3)
                {
                    distance = 8.52 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Uranus")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 3)
                {
                    distance = 18.21 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else if (planet == "Neptune")
            {
                if (daysOnPlanet >= 1 && daysOnPlanet <= 2)
                {
                    distance = 29.09 * 2;
                    Console.WriteLine($"Distance: {distance:f2}");
                    Console.WriteLine($"Total number of days: {distance * AU + daysOnPlanet}");
                }
                else
                {
                    Console.WriteLine("Invalid number of days!");
                }
            }
            else
            {
                Console.WriteLine("Invalid planet name!");
            }

        }
    }
}
