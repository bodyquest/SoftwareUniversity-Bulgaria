using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snowball
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());
            BigInteger best = 0;
            int bestQ = 0;
            double bestSnow = 0;
            double bestTime = 0;
            for (int i = 0; i < snowballs; i++)
            {
                double snowballSnow = double.Parse(Console.ReadLine());
                double snowballTime = double.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());


                BigInteger snowballValue = BigInteger.Pow(((BigInteger)(snowballSnow / snowballTime)), snowballQuality);
                if (snowballValue > best)
                {
                    best = snowballValue;
                    bestQ = snowballQuality;
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                }

            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {best} ({bestQ})");
        }
    }
}
