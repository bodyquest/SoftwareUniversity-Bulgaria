using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Four
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = width * length * height;
            int boxes = 0;
            int sum = 0;

            do
            {
                var input = (Console.ReadLine());
                if (int.TryParse(input, out boxes))
                {
                    sum += boxes;
                }
                else if (input == "Done")
                {
                    Console.WriteLine((volume - sum) + " Cubic meters left.");
                    break;
                }
                if (sum > volume)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume - sum)} Cubic meters more.");
                    break;
                }
            }
            while (sum <= volume);

        }
    }
}
