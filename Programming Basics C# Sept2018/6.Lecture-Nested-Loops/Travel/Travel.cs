using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel
{
    class Travel
    {
        static void Main(string[] args)
        {
            string destination = String.Empty;
            string goTo = String.Empty;
            double sum = 0;
            StringBuilder goingTo = new StringBuilder();
            while (true)
            {
                destination = (Console.ReadLine());
                if (destination == "End")
                {
                    break;
                }
                double budget = double.Parse(Console.ReadLine());
                double money = 0;
                goTo = destination;
                while (sum < budget)
                {
                    money = double.Parse(Console.ReadLine());
                    sum += money;
                }
                if (sum >= budget)
                {
                    goingTo.AppendLine($"Going to {goTo}!");
                    sum = 0;
                }
            } 
            Console.WriteLine(goingTo);
        }
    }
}
