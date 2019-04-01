using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Problem_Three
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            decimal costCairo = 250 * 2 * days + 600;
            decimal costParis = 150 * 2 * days + 350;
            decimal costLima = 400 * 2 * days + 850; ;
            decimal costNewYork = 300 * 2 * days + 650;
            decimal costTokyo = 350 * 2 * days + 700;

            if (days >= 1 && days <= 4)
            {
                if (destination == "Cairo" || destination == "New York")
                {
                    costCairo *= 0.97m;
                    costNewYork *= 0.97m;
                }
            }
            else if (days >= 5 && days <= 9)
            {
                if (destination == "Cairo" || destination == "New York")
                {
                    costCairo *= 0.95m;
                    costNewYork *= 0.95m;
                }
                if (destination == "Paris")
                {
                    costParis *= 0.93m;
                }
            }
            else if (days >= 10 && days <= 24)
            {
                if (destination == "Cairo")
                {
                    costCairo *= 0.90m;
                }
                if (destination == "Paris" || destination == "Tokyo" || destination == "New York")
                {
                    costParis *= 0.88m;
                    costTokyo *= 0.88m;
                    costNewYork *= 0.88m;
                }
            }
            else if (days >= 25 && days <= 49)
            {
                if (destination == "Cairo" || destination == "Tokyo")
                {
                    costCairo *= 0.83m;
                    costTokyo *= 0.83m;
                }
                if (destination == "Lima" || destination == "New York")
                {
                    costLima *= 0.81m;
                    costNewYork *= 0.81m;
                }
                if (destination == "Paris")
                {
                    costParis *= 0.78m;
                }
            }
            else if (days >= 50)
            {
                costCairo *= 0.7m;
                costParis *= 0.7m;
                costLima *= 0.7m;
                costNewYork *= 0.7m;
                costTokyo *= 0.7m;
            }

            if (destination =="Cairo")
            {
                if (budget >= costCairo)
                {
                    Console.WriteLine($"Yes! You have {budget - costCairo:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {costCairo-budget:f2} leva.");
                }

            }
            else if (destination == "Paris")
            {
                if (budget >= costParis)
                {
                    Console.WriteLine($"Yes! You have {budget - costParis:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {costParis - budget:f2} leva.");
                }
            }
            else if (destination == "New York")
            {
                if (budget >= costNewYork)
                {
                    Console.WriteLine($"Yes! You have {budget - costNewYork:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {costNewYork - budget:f2} leva.");
                }
            }
            else if (destination == "Lima")
            {
                if (budget >= costLima)
                {
                    Console.WriteLine($"Yes! You have {budget - costLima:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {costLima - budget:f2} leva.");
                }
            }
            else if (destination == "Tokyo")
            {
                if (budget >= costTokyo)
                {
                    Console.WriteLine($"Yes! You have {budget - costTokyo:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money! You need {costTokyo - budget:f2} leva.");
                }
            }
        }
    }
}
