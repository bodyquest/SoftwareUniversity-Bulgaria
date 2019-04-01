using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyShop
{
    class ToyShop
    {
        static void Main(string[] args)
        {



            double tripExpense = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            double puzzlePrice = 2.60;
            double dollsPrice = 3;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.2;
            double truckPrice = 2;

            int toysCount = puzzles + dolls + teddyBears + minions + trucks;
            double sum = puzzles * puzzlePrice + dolls * dollsPrice + teddyBears * teddyBearPrice + minions * minionPrice + trucks * truckPrice;
            double revenue = 1;

            if (toysCount >= 50)
            {
                sum = sum * (1 - 0.25);
                revenue = sum - sum * 0.1;
                if (revenue >= tripExpense)
                {
                    Console.WriteLine($"Yes! {revenue - tripExpense:f2} lv left.");
                }
                else if (revenue < tripExpense)
                {
                    Console.WriteLine($"Not enough money! {tripExpense - revenue:f2} lv needed.");
                }
            }
            else
            {
                revenue = sum - sum * 0.1;
                if (revenue >= tripExpense)
                {
                    Console.WriteLine($"Yes! {revenue - tripExpense:f2} lv left.");
                }
                else if (revenue < tripExpense)
                {
                    Console.WriteLine($"Not enough money! {tripExpense - revenue:f2} lv needed.");
                }
            }
            
           

        }
    }
}
