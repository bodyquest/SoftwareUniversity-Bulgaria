using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_Or_Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countSum = 0;
            int countMulti = 0;
            for (int one = 1; one < 30; one++)
            {
                for (int two = 1; two <= 30; two++)
                {
                    for (int three = 1; three <= 30; three++)
                    {
                        if (one < two && two < three && one + two + three == n)
                        {
                            Console.WriteLine($"{one} + {two} + {three} = {n}");
                            countSum++;
                        }
                        if (one > two && two > three && one * two * three == n)
                        {
                            Console.WriteLine($"{one} * {two} * {three} = {n}");
                            countMulti++;
                        }
                    }
                }
            }
            if (countSum == 0 && countMulti == 0)
            {
                Console.WriteLine("No!");
                return;
            }
        }
    }
}
