using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 505;
            int div = 1000;

            if (div % n == 0)
            {
                int result = div / 2;
                Console.WriteLine(result);
            }
            else
            {
                int altResult = div / n;
                Console.WriteLine(altResult);
            }
        }
    }
}
