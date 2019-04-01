using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinations
{
    class Combinations
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int count = 0;

            for (int one = 0; one <= n; one++)
            {
                for (int two = 0; two <= n; two++)
                {
                    for (int three = 0; three <= n; three++)
                    {
                        for (int four = 0; four <= n; four++)
                        {
                            for (int five = 0; five <= n; five++)
                            {
                                int sum = one + two + three + four + five;
                                if (sum == n)
                                {
                                    count++;
                                    
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"{count}");
        }
    }
}
