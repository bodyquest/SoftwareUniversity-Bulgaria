using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonomy
{
    class Autonomy
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = length * width * height;

            int cartons = 0;
            int sumCartons = 0;

            while (sumCartons <= volume)
            {
                var input = (Console.ReadLine());
                if (Int32.TryParse(input, out cartons))
                {
                    sumCartons += cartons;
                }
                else if (input == "Done")
                {
                    Console.WriteLine((volume - sumCartons) + " Cubic meters left.");
                    break;
                }
                if (sumCartons > volume)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume - sum)} Cubic meters more.");
                    break;
                }
            }
        }
    }
}
