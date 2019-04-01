using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();            // leap or normal
            double p = double.Parse(Console.ReadLine()); //p = holidays
            double h = double.Parse(Console.ReadLine()); //h = weekend home trips

            var wkndsSofia = 48 - h;
            var playsSofia = wkndsSofia * 3.0 / 4;
            var playsInHoliday = p * 2.0 / 3;
            var playsHome = h;
            var sum = playsSofia + playsHome + playsInHoliday;

            if (year == "leap")
            {
                Console.WriteLine(Math.Truncate(sum + 0.15 * sum)); 
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Truncate(sum));
            }

            // wkndsSofia = 48 - ("h")
            // playsSofia = wkndsSofia * 3.0/4
            // playsHome = h
            // playsInHoliday = p * 2.0/3
            // sum = playsSofia + playsHome + playsInHoliday
            //if (year == "leap")
            //{
            //   Console.WriteLine(Math.Truncate(sum + 0.15 * sum));
            //}
            //
        }
    }
}
