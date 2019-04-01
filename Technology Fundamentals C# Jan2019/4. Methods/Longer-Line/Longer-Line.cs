using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double a1 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());

            if (GetFirstLineLength(x1, y1, x2, y2) >= GetSecondLineLength(a1, b1, a2, b2))
            {
                if (GetEuclideanDistanceFirstPoint(x1, y1, 0, 0) <= GetEuclideanDistanceSecondPoint(x2, y2, 0, 0))
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (GetEuclideanDistanceFirstPoint(a1, b1, 0, 0) <= GetEuclideanDistanceSecondPoint(a2, b2, 0, 0))
                {
                    Console.WriteLine($"({a1}, {b1})({a2}, {b2})");
                }
                else
                {
                    Console.WriteLine($"({a2}, {b2})({a1}, {b1})");
                }
            }
        }

        private static double GetFirstLineLength(double x1, double y1, double x2, double y2)
        {
            double d = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            return d;
        }

        private static double GetSecondLineLength(double a1, double b1, double a2, double b2)
        {
            double d = Math.Sqrt(Math.Pow((a1 - a2), 2) + Math.Pow((b1 - b2), 2));
            return d;
        }

        private static double GetEuclideanDistanceFirstPoint(double x1, double y1, double v1, double v2)
        {
            return Math.Sqrt(Math.Pow((x1 - v1), 2) + Math.Pow((y1 - v2), 2));
        }

        private static double GetEuclideanDistanceSecondPoint(double x2, double y2, double v1, double v2)
        {
            return Math.Sqrt(Math.Pow((x2 - v1), 2) + Math.Pow((y2 - v2), 2));
        }
    }
}
