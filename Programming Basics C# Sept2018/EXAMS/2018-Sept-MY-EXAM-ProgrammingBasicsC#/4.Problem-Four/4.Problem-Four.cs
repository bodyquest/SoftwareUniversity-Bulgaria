using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Problem_Four
{
    class Program
    {
        static void Main(string[] args)
        {
            int budgetForPerformer = int.Parse(Console.ReadLine());
            string input = String.Empty;
            int countGuests = 0;
            int guestsTotal = 0;
            int sumreservations = 0;
            int sumTotal = 0;
            while (input != "The restaurant is full")
            {
                input = Console.ReadLine();
                int.TryParse(input, out int num);
                countGuests += num;
                guestsTotal += num;
                if (countGuests < 5)
                {
                    sumreservations = countGuests * 100;
                }
                else
                {
                    sumreservations = countGuests * 70;
                }
                sumTotal += sumreservations;
                countGuests = 0;
            }

            if (sumTotal >= budgetForPerformer)
            {
                Console.WriteLine($"You have {guestsTotal} guests and {sumTotal - budgetForPerformer} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {guestsTotal} guests and {sumTotal} leva income, but no singer.");
            }
        }
    }
}

