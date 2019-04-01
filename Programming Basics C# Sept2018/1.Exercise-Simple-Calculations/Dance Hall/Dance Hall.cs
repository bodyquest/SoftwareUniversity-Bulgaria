using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        {
            // hall has L and W
            // board is A * A (square)
            // bench - area = hallArea/10
            // dancerArea = 0.4 x 0.4
            // dancerTotalArea = dancerArea + 0.7
            // Math.Floor qty of dancers

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double sideA = double.Parse(Console.ReadLine());

            double hallArea = (length*100) * (width * 100);
            double boardArea = sideA*100 * sideA*100;
            double benchArea = hallArea / 10;
            double dancerArea = 40;
            double dancerTotalArea = dancerArea + 7000;
            double freeSpace = hallArea - boardArea - benchArea;
            double dancersQTY = Math.Floor(freeSpace / dancerTotalArea);

            Console.WriteLine(dancersQTY);
        }
    }
}
