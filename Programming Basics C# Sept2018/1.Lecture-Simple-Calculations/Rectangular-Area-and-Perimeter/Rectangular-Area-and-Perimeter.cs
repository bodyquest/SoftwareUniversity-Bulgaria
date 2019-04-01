using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangular_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var area = (Math.Abs(x1 - x2) * Math.Abs(y1 - y2));
            var perimeter = (Math.Abs(x1 - x2)*2 + Math.Abs(y1 - y2)*2);
            Console.WriteLine("Rectangular area = " + area);
            Console.WriteLine("Rectangular perimeter = " + perimeter);
        }
    }
}
