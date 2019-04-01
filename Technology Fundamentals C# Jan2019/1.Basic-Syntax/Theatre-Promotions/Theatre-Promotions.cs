using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine().ToLower();
            int age = int.Parse(Console.ReadLine());
            var price = 0;

            if (age >= 0 && age <= 122)
            {
                if (day == "weekday")
                {
                    if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                    {
                        price = 12;
                        Console.WriteLine($"{price}$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 18;
                        Console.WriteLine($"{price}$");
                    }
                }

                else if (day == "weekend")
                {
                    if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                    {
                        price = 15;
                        Console.WriteLine($"{price}$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        price = 20;
                        Console.WriteLine($"{price}$");
                    }
                }

                else if (day == "holiday")
                {
                    if (age >= 0 && age <= 18)
                    {
                        Console.WriteLine("5$");
                    }
                    else if (age > 18 && age <= 64)
                    {
                        Console.WriteLine("12$");
                    }
                    else if (age > 64 && age <= 122)
                    {
                        Console.WriteLine("10$");
                    }
                }
            }

            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
