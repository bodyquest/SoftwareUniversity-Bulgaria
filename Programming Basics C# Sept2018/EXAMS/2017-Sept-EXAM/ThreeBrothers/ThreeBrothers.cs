using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBrothers
{
    class ThreeBrothers
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());

            double fishingTime = double.Parse(Console.ReadLine());

            double timeToFinish = 1 / (1 / first + 1 / second + 1 / third);
            timeToFinish *= 1.15;

            Console.WriteLine($"Cleaning time: {timeToFinish:f2}");
            if (timeToFinish < fishingTime)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(fishingTime- timeToFinish)} hours.");
            }
            else if (timeToFinish > fishingTime)
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeToFinish- fishingTime)} hours.");
            }
        }
    }
}
