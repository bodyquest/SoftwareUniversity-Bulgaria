using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex_Fahrenheit_and_Celsius_program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a temperature value:");
            string input = Console.ReadLine().ToLower();
            string value = input.Substring(0, input.Length - 1);
            string identifer = input.Substring(value.Length);

            int numericValue;
            if (int.TryParse(value, out numericValue))
            {
                var toF = (numericValue * 1.8) + 32;
                var toC = (numericValue - 32.0) * 5 / 9;

                if (identifer == "c")
                {
                    Console.WriteLine("You entered a temperature value in Celsius.");
                    Console.WriteLine(Math.Round(toF, 2));
                }
                else if (identifer == "f")
                {
                    Console.WriteLine("You entered a temperature value in Fahrenheit.");
                    Console.WriteLine(Math.Round(toC, 2));
                }
                else
                {
                    Console.WriteLine("Invalid temperature symbol!");
                }
            }
            else
            {
                Console.WriteLine("Invalid temperature value!");
            }

            Console.ReadLine();
        }
    }
}
