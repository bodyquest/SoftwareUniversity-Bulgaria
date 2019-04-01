using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Three
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushiType = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int numPortions = int.Parse(Console.ReadLine());
            char order = char.Parse(Console.ReadLine());

            double bill = 0;
            double totalBill = 0;

            if (restaurantName.Equals("Sushi Zone"))
            {
                if (sushiType.Equals("sashimi"))
                {
                    bill = 4.99;
                }
                else if (sushiType.Equals("maki"))
                {
                    bill = 5.29;
                }
                else if (sushiType.Equals("uramaki"))
                {
                    bill = 5.99;
                }
                else if (sushiType.Equals("temaki"))
                {
                    bill = 4.29;
                }
                //else
                //{
                //    Console.WriteLine("Invalid stock!");
                //    return;
                //}
            }
            else if (restaurantName.Equals("Sushi Time"))
            {
                if (sushiType.Equals("sashimi"))
                {
                    bill = 5.49;
                }
                else if (sushiType.Equals("maki"))
                {
                    bill = 4.69;
                }
                else if (sushiType.Equals("uramaki"))
                {
                    bill = 4.49;
                }
                else if (sushiType.Equals("temaki"))
                {
                    bill = 5.19;
                }
                //else
                //{
                //    Console.WriteLine("Invalid stock!");
                //    return;
                //}
            }
            else if (restaurantName.Equals("Sushi Bar"))
            {
                if (sushiType.Equals("sashimi"))
                {
                    bill = 5.25;
                }
                else if (sushiType.Equals("maki"))
                {
                    bill = 5.55;
                }
                else if (sushiType.Equals("uramaki"))
                {
                    bill = 6.25;
                }
                else if (sushiType.Equals("temaki"))
                {
                    bill = 4.75;
                }
                //else
                //{
                //    Console.WriteLine("Invalid stock!");
                //    return;
                //}
            }
            else if (restaurantName.Equals("Asian Pub"))
            {
                if (sushiType.Equals("sashimi"))
                {
                    bill = 4.50;
                }
                else if (sushiType.Equals("maki"))
                {
                    bill = 4.80;
                }
                else if (sushiType.Equals("uramaki"))
                {
                    bill = 5.50;
                }
                else if (sushiType.Equals("temaki"))
                {
                    bill = 5.50;
                }
            }
            else
            {
                Console.WriteLine($"{restaurantName} is invalid restaurant!");
                return;
            }

            totalBill = numPortions * bill;
            double delivery = 0.2 * totalBill;
            if (order =='Y')
            {
                Console.WriteLine($"Total price: {Math.Ceiling(totalBill + delivery)} lv.");
            }
            else if (order == 'N')
            {
                Console.WriteLine($"Total price: {Math.Ceiling(totalBill)} lv.");
            }


            
        }
    }
}
