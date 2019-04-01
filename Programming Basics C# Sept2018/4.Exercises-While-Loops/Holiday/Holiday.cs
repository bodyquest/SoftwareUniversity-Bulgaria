using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holiday
{
    class Holiday
    {
        static void Main(string[] args)
        {
            double holidayCost = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int count = 0;
            int countSpend = 0;

            while (true)
            {
                string fiscalAction = Console.ReadLine();
                double sum = double.Parse(Console.ReadLine());
                count++;
                if (fiscalAction == "spend")
                {
                    countSpend++;
                    budget -= sum;
                    if (budget < 0)
                    {
                        budget = 0;
                    }
                }
                if (countSpend == 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{count}");
                    break;
                }
                if (fiscalAction == "save")
                {
                    countSpend= 0;
                    budget += sum;
                    if (budget >= holidayCost)
                    {
                        Console.WriteLine($"You saved the money for {count} days.");
                        break;
                    }
                }
            }
        }
    }
}
