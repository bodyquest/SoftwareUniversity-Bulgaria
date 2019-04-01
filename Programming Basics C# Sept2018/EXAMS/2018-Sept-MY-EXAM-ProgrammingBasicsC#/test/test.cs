using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            int guestCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            int costForGuests = 20;

            int coversAll = guestCount * costForGuests;
            int balance = budget - coversAll;


            int zeroBalance = 0;

            int fireWorksCost = (int)((balance * 100 - balance * 60) / 100);

            if (balance > 0)
            {
                Console.WriteLine("Yes! {0} lv are for fireworks and {1} lv are for donation.", fireWorksCost, balance - fireWorksCost);
            }

            if (balance == 0)
            {
                Console.WriteLine("Yes! {0} lv are for fireworks and {1} lv are for donation.", zeroBalance, zeroBalance);
            }

            if (balance < 0)
            {
                Console.WriteLine("They won't have enough money to pay the covert. They will need {0} lv more.", balance * (-1));
            }


        }
    }
}
