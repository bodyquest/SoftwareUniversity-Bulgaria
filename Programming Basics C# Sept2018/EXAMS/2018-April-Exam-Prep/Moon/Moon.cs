using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon
{
    class Moon
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());

            double tripTime = (double)384400*2/ speed;
            double totalTime = tripTime + 3;
            double totalFuel = (double)384400 * 2 / 100 * fuel;

            Console.WriteLine($"{Math.Ceiling(totalTime)}");
            Console.WriteLine($"{Math.Ceiling(totalFuel)}");

        }
    }
}
