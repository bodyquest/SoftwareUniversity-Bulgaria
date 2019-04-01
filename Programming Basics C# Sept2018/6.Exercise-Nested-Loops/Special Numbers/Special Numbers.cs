using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int one = 1; one <= 9; one++)
            {
                for (int two = 1; two <= 9; two++)
                {
                    for (int three = 1; three <= 9; three++)
                    {
                        for (int four = 1; four <= 9; four++)
                        {
                            if (N % one == 0 && N % two == 0 && N % three == 0 && N % four == 0 )
                            {
                                Console.Write($"{one}{two}{three}{four}");
                                Console.Write(" ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
