using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            int count200 = 0;
            int count400 = 0;
            int count600 = 0;
            int count800 = 0;
            int countOver800 = 0;

            for (int i = 1; i <= n; i++)
            {
                num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    count200++;
                }
                else if (num < 400)
                {
                    count400++;
                }
                else if (num < 600)
                {
                    count600++;
                }
                else if (num <800)
                {
                    count800++;
                }
                else if (num >= 800)
                {
                    countOver800++;
                }
            }
            Console.WriteLine($"{(double)count200 / n * 100:f2}%");
            Console.WriteLine($"{(double)count400 / n * 100:f2}%");
            Console.WriteLine($"{(double)count600 / n * 100:f2}%");
            Console.WriteLine($"{(double)count800 / n * 100:f2}%");
            Console.WriteLine($"{(double)countOver800 / n * 100:f2}%");

        }
    }
}
