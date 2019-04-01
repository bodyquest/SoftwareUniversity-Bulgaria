using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int one = 1; one <= 9; one++)
            {
                for (int two = 1; two <= 9; two++)
                {
                    for (int three = 1; three <= 9; three++)
                    {
                        for (int four = 1; four <= 9; four++)
                        {
                            if (one + two == (three+ four) && n% (one+two) ==0)
                            {
                                Console.Write($"{one}{two}{three}{four} ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
