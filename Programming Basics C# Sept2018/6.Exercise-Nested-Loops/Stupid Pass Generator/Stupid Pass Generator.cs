using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stupid_Pass_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());

            for (int first = 1; first <= N; first++)
            {
                for (int second = 1; second <= N; second++)
                {
                    for (char third = 'a'; third < 'a'+ L; third++)
                    {
                        for (char fourth = 'a'; fourth < 'a' + L; fourth++)
                        {
                            for (int fifth = 1; fifth <= N; fifth++)
                            {
                                if (fifth > first && fifth > second)
                                {
                                    Console.Write($"{first}{second}{third}{fourth}{fifth}");
                                    Console.Write(" ");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
