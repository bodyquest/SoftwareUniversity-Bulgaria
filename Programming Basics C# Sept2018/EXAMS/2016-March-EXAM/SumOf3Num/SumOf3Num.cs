using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOf3Num
{
    class SumOf3Num
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a + b == c)
            {
                if (b >= a)
                {
                    Console.WriteLine($"{a} + {b} = {c}");
                }
                else
                {
                    Console.WriteLine($"{b} + {a} = {c}");
                }
            }
            else if (a + c == b)
            {
                if (c >= a)
                {
                    Console.WriteLine($"{a} + {c} = {b}");
                }
                else
                {
                    Console.WriteLine($"{c} + {a} = {b}");
                }
            }
            else if (b + c == a)
            {
                if (c >= b)
                {
                    Console.WriteLine($"{b} + {c} = {a}");
                }
                else
                {
                    Console.WriteLine($"{c} + {b} = {a}");
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
