using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballKit
{
    class FootballKit
    {
        static void Main(string[] args)
        {
            double teePrice = double.Parse(Console.ReadLine());
            double giftAmount = double.Parse(Console.ReadLine());

            double shortsPrice = teePrice * 0.75;
            double socksPrice = shortsPrice * 0.2;
            double shoesPrice = 2 * (teePrice + shortsPrice);

            double sum = (teePrice + shortsPrice + socksPrice + shoesPrice)* (1-0.15);
            if (sum >= giftAmount)
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {sum:f2} lv.");
            }
            else if (sum < giftAmount)
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {giftAmount - sum:f2} lv. more.");
            }
        }
    }
}
