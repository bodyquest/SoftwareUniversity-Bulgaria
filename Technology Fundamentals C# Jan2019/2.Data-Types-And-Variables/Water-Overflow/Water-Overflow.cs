using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int tank = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                if (tank + liters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }

                else
                {
                    tank += liters;
                }
            }

            Console.WriteLine(tank);
        }
    }
}
