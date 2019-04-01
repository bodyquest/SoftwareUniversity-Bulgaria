using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayAQUARIUM
{
    class BirthdayAQUARIUM
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            percent = percent * 0.01;
            double volumeL = length * width * height / 1000;
            double capacity = volumeL * (1 - percent);
            Console.WriteLine($"{capacity:F3}");

        }
    }
}
