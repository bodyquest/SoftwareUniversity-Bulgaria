using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluJoinery
{
    class AluJoinery
    {
        static void Main(string[] args)
        {
            int countAluFrames = int.Parse(Console.ReadLine());
            string frameType = Console.ReadLine();
            string delivery = Console.ReadLine();

            decimal framePrice = 0m;
            if (countAluFrames < 10)
            {
                Console.WriteLine("Invalid order");
            }

            if (frameType == "90X130")
            {
                framePrice = 110 * countAluFrames;
                if (countAluFrames > 30 && countAluFrames <= 60)
                {
                    framePrice *= 0.95m;
                }
                else if (countAluFrames > 60)
                {
                    framePrice *= 0.92m;
                }
            }
            if (frameType == "100X150")
            {
                framePrice = 140 * countAluFrames;
                if (countAluFrames > 40 && countAluFrames <= 80)
                {
                    framePrice *= 0.94m;
                }
                else if (countAluFrames > 80)
                {
                    framePrice *= 0.90m;
                }
            }
            if (frameType == "130X180")
            {
                framePrice = 190 * countAluFrames;
                if (countAluFrames > 20 && countAluFrames <= 50)
                {
                    framePrice *= 0.93m;
                }
                else if (countAluFrames > 50)
                {
                    framePrice *= 0.88m;
                }
            }
            if (frameType == "200X300")
            {
                framePrice = 250 * countAluFrames;
                if (countAluFrames > 25 && countAluFrames <= 50)
                {
                    framePrice *= 0.91m;
                }
                else if (countAluFrames > 50)
                {
                    framePrice *= 0.86m;
                }
            }
            if (delivery == "With delivery")
            {
                framePrice += 60;
                if (countAluFrames > 99)
                {
                    framePrice *= 0.96m;
                    Console.WriteLine($"{framePrice:f2} BGN");
                }
                else
                {
                    Console.WriteLine($"{framePrice:f2} BGN");
                }
            }
            else if (delivery == "Without delivery")
            {
                if (countAluFrames > 99)
                {
                    framePrice *= 0.96m;
                    Console.WriteLine($"{framePrice:f2} BGN");
                }
                else
                {
                    Console.WriteLine($"{framePrice:f2} BGN");
                }
            }
        }
    }
}
