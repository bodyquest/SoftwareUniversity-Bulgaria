using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footbal_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirs = Console.ReadLine();
            int souvenirsQty = int.Parse(Console.ReadLine());

            double total = 0;

            decimal flags = 0m;
            decimal caps = 0m;
            decimal posters = 0m;
            decimal stickers = 0m;

            if (team.Equals ("Argenitna"))
            {
                if (souvenirs.Equals("flags"))
                {
                    total = 3.25;
                }
                else if (souvenirs.Equals("caps"))
                {
                    total = 7.20;
                }
                else if (souvenirs.Equals("posters"))
                {
                    total = 5.10;
                }
                else if (souvenirs.Equals("stickers"))
                {
                    total = 1.25;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team.Equals("Brazil"))
            {
                if (souvenirs.Equals("flags"))
                {
                    total = 4.2;
                }
                else if (souvenirs.Equals("caps"))
                {
                    total = 8.5;
                }
                else if (souvenirs.Equals("posters"))
                {
                    total = 5.35;
                }
                else if (souvenirs.Equals("stickers"))
                {
                    total = 1.2;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team.Equals("Croatia"))
            {
                if (souvenirs.Equals("flags"))
                {
                    total = 2.75;
                }
                else if (souvenirs.Equals("caps"))
                {
                    total = 6.9;
                }
                else if (souvenirs.Equals("posters"))
                {
                    total = 4.95;
                }
                else if (souvenirs.Equals("stickers"))
                {
                    total = 1.1;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else if (team.Equals("Denmark"))
            {
                if (souvenirs.Equals("flags"))
                {
                    total = 3.1;
                }
                else if (souvenirs.Equals("caps"))
                {
                    total = 6.5;
                }
                else if (souvenirs.Equals("posters"))
                {
                    total = 4.8;
                }
                else if (souvenirs.Equals("stickers"))
                {
                    total = 0.9;
                }
                else
                {
                    Console.WriteLine("Invalid stock!");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid country!");
                return;
            }
                
            double bill = souvenirsQty * total;

            Console.WriteLine($"Pepi bought {souvenirsQty} {souvenirs} of {team} for {bill:f2} lv.");

        }
    }
}
