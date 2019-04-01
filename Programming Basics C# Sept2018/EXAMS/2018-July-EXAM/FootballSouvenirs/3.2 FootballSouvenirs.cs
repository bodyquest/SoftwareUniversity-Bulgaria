using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenir = Console.ReadLine();
            int num = int.Parse(Console.ReadLine());
            double flagsPrice = 1;
            double capsPrice = 1;
            double postersPrice = 1;
            double stickersPrice = 1;

            if (team == "Argentina")
            {
                if (souvenir == "flags")
                {
                    flagsPrice = 3.25;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * flagsPrice:f2} lv.");
                }
                if (souvenir == "caps")
                {
                    capsPrice = 7.20;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * capsPrice:f2} lv.");
                }
                if (souvenir == "posters")
                {
                    postersPrice = 5.10;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * postersPrice:f2} lv.");
                }
                if (souvenir == "stickers")
                {
                    stickersPrice = 1.25;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * stickersPrice:f2} lv.");
                }
            }
            else if (team == "Brazil")
            {
                if (souvenir == "flags")
                {
                    flagsPrice = 4.20;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * flagsPrice:f2} lv.");
                }
                if (souvenir == "caps")
                {
                    capsPrice = 8.50;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * capsPrice:f2} lv.");
                }
                if (souvenir == "posters")
                {
                    postersPrice = 5.35;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * postersPrice:f2} lv.");
                }
                if (souvenir == "stickers")
                {
                    stickersPrice = 1.20;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * stickersPrice:f2} lv.");
                }
            }
            else if (team == "Croatia")
            {
                if (souvenir == "flags")
                {
                    flagsPrice = 2.75;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * flagsPrice:f2} lv.");
                }
                if (souvenir == "caps")
                {
                    capsPrice = 6.90;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * capsPrice:f2} lv.");
                }
                if (souvenir == "posters")
                {
                    postersPrice = 4.95;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * postersPrice:f2} lv.");
                }
                if (souvenir == "stickers")
                {
                    stickersPrice = 1.10;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * stickersPrice:f2} lv.");
                }
            }
            else if (team == "Denmark")
            {
                if (souvenir == "flags")
                {
                    flagsPrice = 3.10;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * flagsPrice:f2} lv.");
                }
                if (souvenir == "caps")
                {
                    capsPrice = 6.50;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * capsPrice:f2} lv.");
                }
                if (souvenir == "posters")
                {
                    postersPrice = 4.80;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * postersPrice:f2} lv.");
                }
                if (souvenir == "stickers")
                {
                    stickersPrice = 0.90;
                    Console.WriteLine($"Pepi bought {num} {souvenir} of {team} for {num * stickersPrice:f2} lv.");
                }
            }
            else if (team != "Argentina" && team != "Brazil" && team != "Croatia" && team != "Denmark")
            {
                Console.WriteLine("Invalid country!");
            }

            if (souvenir != "flags" && souvenir != "caps" && souvenir != "posters" && souvenir != "stickers")
            {
                Console.WriteLine("Invalid stock!");
            }
        }
    }
}
