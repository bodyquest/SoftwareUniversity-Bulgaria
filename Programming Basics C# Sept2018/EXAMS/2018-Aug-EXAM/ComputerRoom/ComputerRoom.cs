using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRoom
{
    class ComputerRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hoursSpent = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();

            double price = 1;
            if (month == "march" || month == "april" || month == "may")
            {
                if (partOfDay == "day")
                {
                    price = 10.5;
                }
                else if (partOfDay == "night")
                {
                    price = 8.4;
                }
                if (peopleCount >= 4)
                {
                    price = price - price * 0.1;
                }
                if (hoursSpent >= 5)
                {
                    price = price / 2;
                }
                Console.WriteLine($"Price per person for one hour: {price:f2}");
                Console.WriteLine($"Total cost of the visit: {price * peopleCount * hoursSpent:f2}");
            }
            else if (month == "june" || month == "july" || month == "august")
            {

                if (partOfDay == "day")
                {
                    price = 12.6;
                }
                else if (partOfDay == "night")
                {
                    price = 10.2;
                }
                if (peopleCount >= 4)
                {
                    price = price - price * 0.1;
                }
                if (hoursSpent >= 5)
                {
                    price = price / 2;
                }
                Console.WriteLine($"Price per person for one hour: {price:f2}");
                Console.WriteLine($"Total cost of the visit: {price * peopleCount * hoursSpent:f2}");
            }
        }
    }
}
