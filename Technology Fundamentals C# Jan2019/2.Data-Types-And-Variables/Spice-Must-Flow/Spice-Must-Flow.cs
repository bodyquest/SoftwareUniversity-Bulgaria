using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());
            int extracted = 0;
            int totalExtracted = 0;
            int workers = 26;
            int days = 0;

            while (startYield >= 100)
            {
                extracted = startYield - workers;
                startYield -= 10;
                totalExtracted += extracted;
                days++;
                if (startYield < 100)
                {
                    totalExtracted -= workers;
                }
            }

            Console.WriteLine(days);
            Console.WriteLine(totalExtracted);
        }
    }
}
