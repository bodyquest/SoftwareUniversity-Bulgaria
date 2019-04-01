using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 0;
            bool isSpecial = false;
            for (int i = 1; i <= input; i++)
            {
                num = i;
                while (i > 0)
                {
                    sum += i % 10;
                    i /= 10;
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", num, isSpecial);
                sum = 0;
                i = num;

            }
        }
    }
}
