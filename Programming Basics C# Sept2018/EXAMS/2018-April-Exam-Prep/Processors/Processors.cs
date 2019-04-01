using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processors
{
    class Processors
    {
        static void Main(string[] args)
        {
            int targetCount = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            double processorPrice = 110.10;
            int actualCount = 0;

            actualCount = employees * workDays * 8 / 3;
            if (actualCount > targetCount)
            {
                Console.WriteLine($"Profit: -> {(actualCount-targetCount) * processorPrice:f2} BGN");
            }
            else if (actualCount < targetCount)
            {
                Console.WriteLine($"Losses: -> {(targetCount - actualCount) * processorPrice:f2} BGN");
            }
        }
    }
}
