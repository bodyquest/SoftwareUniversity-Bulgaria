using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string screen = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            double revenue = 1;

            int capacity = rows * columns;

            if (screen == "Premiere")
            {
                revenue = 12 * capacity;
            }
            else if (screen == "Normal")
            {
                revenue = 7.50 * capacity;
            }
            else if (screen == "Discount")
            {
                revenue = 5.00 * capacity;
            }
            Console.WriteLine($"{revenue:f2}");
            Console.WriteLine("leva");

        }
    }
}
