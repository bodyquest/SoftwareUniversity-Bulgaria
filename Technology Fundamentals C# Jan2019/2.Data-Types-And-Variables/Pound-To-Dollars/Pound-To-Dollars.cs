using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pound_To_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal num = decimal.Parse(Console.ReadLine());
            decimal dollars = num * 1.31m;

            Console.WriteLine($"{dollars:f3}");
        }
    }
}
