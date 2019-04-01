using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Integer
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            FindTopInteger(n);
        }

        private static void FindTopInteger(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                int sum = 0;
                int num = i;
                bool isOdd = false;
                while (num > 0)
                {
                    var digit = num % 10;
                    if (digit % 2 != 0)
                    {
                        isOdd = true;
                    }
                    sum += digit;
                    num /= 10;
                }

                if (sum % 8 == 0 && isOdd)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
