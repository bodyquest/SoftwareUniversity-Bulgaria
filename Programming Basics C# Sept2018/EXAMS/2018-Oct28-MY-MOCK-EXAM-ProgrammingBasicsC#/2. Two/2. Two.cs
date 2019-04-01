using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Two
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double avgHeightAstronauts = double.Parse(Console.ReadLine());

            double astronautCabin = 4 * (avgHeightAstronauts + 0.4);
            double volume = width * length * height;
            double astronautCount = Math.Floor(volume/ astronautCabin);

            if (astronautCount >= 3 && astronautCount <= 10)
            {
                Console.WriteLine($"The spacecraft holds {astronautCount} astronauts.");
            }
            else if (astronautCount < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
            else
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
        }
    }
}
