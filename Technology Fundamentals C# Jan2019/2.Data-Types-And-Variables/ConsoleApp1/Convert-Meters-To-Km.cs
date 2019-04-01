using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_Meters_To_Km
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            double km = (double)num / 1000;

            Console.WriteLine($"{km:f2}");
        }
    }
}
