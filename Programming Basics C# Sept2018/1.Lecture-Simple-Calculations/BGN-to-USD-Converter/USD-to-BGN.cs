using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGN_to_USD_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Submit amount in USD: ");
            var USD = double.Parse(Console.ReadLine());
            var BGN = Math.Round(USD * 1.79549, 2);
            Console.WriteLine("Amount in BGN is: " + BGN);


        }
    }
}
