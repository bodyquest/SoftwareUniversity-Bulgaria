using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            // Find maximum element 
            int get_max = Math.Max(a, Math.Max(b, c));

            // Find minimum element 
            int get_min = -Math.Max(-a, Math.Max(-b, -c));

            int get_mid = (a + b + c) -
                          (get_max + get_min);

            Console.WriteLine(get_max);
            Console.WriteLine(get_mid);
            Console.WriteLine(get_min);

        }
    }
}
