using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPhones
{
    class CellPhones
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int gsmCount = int.Parse(Console.ReadLine());
            string brand = Console.ReadLine();

            decimal gsmCost = 0m;
            decimal totalCost = 0m;

            if (brand == "Gsm4e")
            {
                gsmCost = 20.50m;
                if (gsmCount <= 10)
                {
                    gsmCost = 20.50m * 0.99m;
                    totalCost = gsmCost * gsmCount;
                }
                if (gsmCount > 10 && gsmCount <= 20)
                {
                    totalCost = gsmCost * gsmCount * 0.97m;
                }
                else if (gsmCount > 20 && gsmCount <= 50)
                {
                    totalCost = gsmCost * gsmCount * 0.94m;
                }
                else if (gsmCount >50)
                {
                    totalCost = gsmCost * gsmCount * 0.92m;
                }

            }
            else if (brand == "Mobifon4e")
            {
                gsmCost = 50.75m;
                if (gsmCount <= 10)
                {
                    gsmCost = 50.75m * 0.98m;
                    totalCost = gsmCost * gsmCount;
                }
                
                if (gsmCount > 10 && gsmCount <= 20)
                {
                    totalCost = gsmCost * gsmCount * 0.96m;
                }
                else if (gsmCount > 20 && gsmCount <= 50)
                {
                    totalCost = gsmCost * gsmCount * 0.93m;
                }
                else if (gsmCount > 50)
                {
                    totalCost = gsmCost * gsmCount * 0.91m;
                }
            }
            else if (brand == "Telefon4e")
            {
                gsmCost = 115m;
                if (gsmCount <= 10)
                {
                    gsmCost = 115m * 0.97m;
                    totalCost = gsmCost * gsmCount;
                }
                if (gsmCount > 10 && gsmCount <= 20)
                {
                    totalCost = gsmCost * gsmCount * 0.95m;
                }
                else if (gsmCount > 20 && gsmCount <= 50)
                {
                    totalCost = gsmCost * gsmCount * 0.92m;
                }
                else if (gsmCount > 50)
                {
                    totalCost = gsmCost * gsmCount * 0.9m;
                }
            }

            if (budget >= totalCost)
            {
                Console.WriteLine($"The company bought all mobile phones. {budget - totalCost:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money for all mobiles. Company needs {totalCost - budget:f2} more leva.");
            }

        }
    }
}
