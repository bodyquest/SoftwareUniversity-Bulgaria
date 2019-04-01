using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special__Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = i;
                while (num > 0)
                {
                    int integer = num % 10;
                    sum += integer;
                    num /= 10;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }

                else
                {
                    Console.WriteLine($"{i} -> False");
                }

                sum = 0;
                
            }
        }
    }
}
