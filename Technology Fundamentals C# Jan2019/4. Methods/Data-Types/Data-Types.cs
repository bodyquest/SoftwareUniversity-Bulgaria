using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string input = Console.ReadLine();

            GetCalculationDependingOnType(type, input);
        }

        private static void GetCalculationDependingOnType(string type, string input)
        {
            switch (type)
            {
                case "int": int.TryParse(input, out int num); Console.WriteLine(num * 2); break;
                case "real": double.TryParse(input, out double real); Console.WriteLine($"{real * 1.5:f2} "); break;
                case "string": Console.WriteLine($"${input}$"); break;
                default:
                    break;
            }
        }
    }
}
