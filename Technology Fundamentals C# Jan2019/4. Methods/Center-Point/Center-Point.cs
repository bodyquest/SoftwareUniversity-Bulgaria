using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            if (GetEuclideanDistanceFirstPoint(x1, y1, 0, 0) <= GetEuclideanDistanceSecondPoint(x2, y2, 0, 0))
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }

        }

        private static double GetEuclideanDistanceFirstPoint(double x1, double y1, double v1, double v2)
        {
            return Math.Sqrt(Math.Pow(x1 - v1, 2) + Math.Pow(y1 - v2, 2)); ;
        }

        private static double GetEuclideanDistanceSecondPoint(double x2, double y2, double v1, double v2)
        {
            return Math.Sqrt(Math.Pow((x2 - v1), 2) + Math.Pow((y2 - v2), 2));
        }
    }
}
