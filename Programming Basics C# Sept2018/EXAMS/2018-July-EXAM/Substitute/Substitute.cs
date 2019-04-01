using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substitute
{
    class Substitute
    {
        static void Main(string[] args)
        {
            int K = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            int k = 0;
            int l = 0;
            int m = 0;
            int n = 0;

            int count = 0;

            for (k = K; k <= 8; k++)
            {
                for (l = 9; l >= L; l--)
                {
                    for (m = M; m <= 8; m++)
                    {
                        for (n = 9; n >= N; n--)
                        {
                            if (k % 2 == 0 && m % 2 == 0 && l % 2 != 0 && n % 2 != 0)
                            {
                                if (k == m && l == n)
                                {
                                    Console.WriteLine("Cannot change the same player.");
                                }
                                else
                                {
                                    Console.WriteLine($"{k}{l} - {m}{n}");
                                    count++;
                                }

                                if (count == 6)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
