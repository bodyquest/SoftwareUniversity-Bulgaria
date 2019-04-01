using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOperator
{
    class MobileOperator
    {
        static void Main(string[] args)
        {
            string duration = Console.ReadLine();
            string contractType = Console.ReadLine();
            string hasInternet = Console.ReadLine();
            int months = int.Parse(Console.ReadLine());

            decimal price = 0;
            decimal sum = 0;

            if (duration == "one")
            {
                if (contractType == "Small")
                {
                        price = 9.98m;
                }
                else if (contractType == "Middle")
                {
                        price = 18.99m;
                }
                else if (contractType == "Large")
                {
                    price = 25.98m;
                }
                else if (contractType == "ExtraLarge")
                {
                    price = 35.99m;
                }
            }
            else if (duration == "two")
            {
                if (contractType == "Small")
                {
                    price = 8.58m;
                }
                else if (contractType == "Middle")
                {
                    price = 17.09m;
                }
                else if (contractType == "Large")
                {
                    price = 23.59m;
                }
                else if (contractType == "ExtraLarge")
                {
                    price = 31.79m;
                }
            }

            if (hasInternet == "yes")
            {
                if (price <= 10)
                {
                    price += 5.50m;
                }
                else if (price <= 30)
                {
                    price += 4.35m;
                }
                else if (price > 30)
                {
                    price += 3.85m;
                }
            }

            if (duration == "two")
            {
                price *= 0.9625m;
            }
            Console.WriteLine($"{price* months:f2} lv.");
        }
    }
}
