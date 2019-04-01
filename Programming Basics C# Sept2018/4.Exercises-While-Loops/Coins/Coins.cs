using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coins
{
    class Coins
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////

            double toReturn = double.Parse(Console.ReadLine());
            double lv = Math.Floor(toReturn);
            double coins = Math.Round((toReturn - lv) * 100);
            double count = 0;

            while (lv > 0)
            {
                if (lv >= 2)
                {
                    count += 1;
                    lv -= 2;
                }
                else if (lv >= 1)
                {
                    count += 1;
                    lv -= 1;
                }
            }
            while (coins > 0)
            {
                if (coins >= 50)
                {
                    count += 1;
                    coins -= 50;
                }
                else if (coins >= 20)
                {
                    count += 1;
                    coins -= 20;
                }
                else if (coins >= 10)
                {
                    count += 1;
                    coins -= 10;
                }
                else if (coins >= 05)
                {
                    count += 1;
                    coins -= 05;
                }
                else if (coins >= 02)
                {
                    count += 1;
                    coins -= 02;
                }
                else if (coins >= 01)
                {
                    count += 1;
                    coins -= 01;
                    break;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(count);
        }
    }
}

