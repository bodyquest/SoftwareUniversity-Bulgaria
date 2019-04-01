using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelsiusToFahrenheit
{
    class MyCelsiusToFahrenheit
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var conversion = Console.ReadLine();
            var toF = (n * 1.8) + 32;
            var toC = (n - 32) * 5 / 9;

            if (conversion.Equals("c"))
            {
                Console.WriteLine(Math.Round(toF, 2));
            }
            else if (conversion.Equals("f"))
            {
                Console.WriteLine(Math.Round(toC, 2));
            }


            //Console.WriteLine("Fahrenheit= {0}", F);
        }
    }
}
