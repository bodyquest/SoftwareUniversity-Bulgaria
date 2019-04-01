using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Problem_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            int costForGuests = guestsCount * 20;

            if (budget >= costForGuests)
            {
                int spareMoney = budget - costForGuests;
                double fireworks = spareMoney * 0.4;

                Console.WriteLine($"Yes! {Math.Round(fireworks)} lv are for fireworks and {Math.Round(spareMoney - fireworks)} lv are for donation.");
            }
            else if (costForGuests > budget)
            {
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {costForGuests - budget} lv more.");
            }
        }
    }
}
