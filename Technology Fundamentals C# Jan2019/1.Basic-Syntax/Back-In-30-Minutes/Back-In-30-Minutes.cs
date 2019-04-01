using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int outputMin = minutes + 30;
            if (outputMin > 59)
            {
                outputMin -= 60;
                hours++;
            }

            if (hours > 23)
            {
                hours = 0;
            }

            if (outputMin < 10)
            {
                Console.WriteLine($"{hours}:0{outputMin}");
            }
            else
            {
                Console.WriteLine($"{hours}:{outputMin}");
            }
        }
    }
}
