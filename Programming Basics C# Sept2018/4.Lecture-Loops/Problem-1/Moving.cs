using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int wide = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int high = int.Parse(Console.ReadLine());

            int volume = wide * length * high;
            int sum = 0;
            int boxes = 0;

            do
            {
                var input = (Console.ReadLine());
                if (Int32.TryParse(input, out boxes))
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
