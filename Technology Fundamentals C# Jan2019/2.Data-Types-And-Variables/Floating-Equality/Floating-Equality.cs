using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double one = double.Parse(Console.ReadLine());
            double two = double.Parse(Console.ReadLine());
            double eps = 0.000001;

            if (Math.Abs(one - two) >= eps)
            {
                Console.WriteLine("False");
            }

            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
