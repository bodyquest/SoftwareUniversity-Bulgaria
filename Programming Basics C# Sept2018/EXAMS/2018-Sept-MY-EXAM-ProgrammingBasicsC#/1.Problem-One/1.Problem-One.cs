using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Problem_One
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double barLength = double.Parse(Console.ReadLine());

            double area = length * width;
            double dancing = area * 0.19;
            double forGuests = area - dancing-barLength * barLength;

            Console.WriteLine($"{Math.Ceiling(forGuests/3.2)}");
        }
    }
}
