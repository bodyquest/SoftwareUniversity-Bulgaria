using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());
            GetMultiplicationResultSign(n1, n2, n3);
        }

        private static void GetMultiplicationResultSign(double n1, double n2, double n3)
        {
            if (n1 == 0 || n2 == 0 || n3 == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                if ((n1 > 0 && n2 > 0 && n3 > 0) || (n1 > 0 && n2 < 0 && n3 < 0) || (n1 < 0 && n2 > 0 && n3 < 0) || (n1 < 0 && n2 < 0 && n3 > 0))
                {
                    Console.WriteLine("positive");
                }
                else
                {
                    Console.WriteLine("negative");
                }

                
            }
        }
    }
}
