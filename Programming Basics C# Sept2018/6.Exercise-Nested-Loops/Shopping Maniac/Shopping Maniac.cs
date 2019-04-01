using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Maniac
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            string shopping = String.Empty;
            string input = String.Empty;
            decimal moneySpent = 0m;
            decimal spend = 0m;
            int count = 0;

            while (input != "enough")
            {
                input = Console.ReadLine();
                while (input == "enter")
                {
                    shopping = Console.ReadLine();
                    if (shopping == "leave")
                    {
                        break;
                    }
                    decimal.TryParse(shopping, out spend);
                    if (budget < spend)
                    {
                        Console.WriteLine("Not enough money.");
                        continue;
                    }
                    else if (budget >= spend)
                    {
                        moneySpent += spend;
                        budget -= spend;
                        count++;
                    }
                    if (budget == 0)
                    {
                        Console.WriteLine($"For {count} clothes I spent {moneySpent} lv and have {budget} lv left.");
                        return;
                    }
                }
            }
            Console.WriteLine($"For {count} clothes I spent {moneySpent} lv and have {budget} lv left.");
        }
    }
}
