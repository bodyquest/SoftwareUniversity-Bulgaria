using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenPowerOf2
{
    class EvenPowerOf2
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 0; i <= n; i+=2)
            {
                Console.WriteLine(num);
                num *= 4;
            }
        }
    }
}
