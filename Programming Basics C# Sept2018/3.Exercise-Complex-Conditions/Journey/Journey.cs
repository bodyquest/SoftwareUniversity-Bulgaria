using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = String.Empty;
            string place = String.Empty;

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    budget = budget * 0.3;
                    destination = "Bulgaria";
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 0.7;
                    destination = "Bulgaria";
                    place = "Hotel";
                }
                Console.WriteLine("Somewhere in {0}", destination);
                Console.WriteLine("{0} - {1:f2}", place, budget);
            }
            else if (budget <= 1000)
            {
                if (season == "summer")
                {
                    budget = budget * 0.4;
                    destination = "Balkans";
                    place = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 0.8;
                    destination = "Balkans";
                    place = "Hotel";
                }
                Console.WriteLine("Somewhere in {0}", destination);
                Console.WriteLine("{0} - {1:f2}", place, budget);
            }
            else if (budget > 1000)
            {
                if (season == "summer")
                {
                    budget = budget * 0.9;
                    destination = "Europe";
                    place = "Hotel";
                }
                else if (season == "winter")
                {
                    budget = budget * 0.9;
                    destination = "Europe";
                    place = "Hotel";
                }
                Console.WriteLine("Somewhere in {0}", destination);
                Console.WriteLine("{0} - {1:f2}", place, budget);
            }

        }
    }
}
