using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long f0 = 1;
            long f1 = 1;
            long f2 = 2;

            if (n == 3)
            {
                Console.WriteLine("1 1 2");
                return;
            }
            else if (n == 2)
            {
                Console.WriteLine("1 1");
                return;
            }
            else if (n == 1)
            {
                Console.WriteLine("1");
                return;
            }
            else if (n == 0)
            {
                Console.WriteLine(0);
            }

            StringBuilder triboSeq = new StringBuilder();
            triboSeq.Append(f0 + " ");
            triboSeq.Append(f1 + " ");
            triboSeq.Append(f2 + " ");

            for (int i = 3; i <= n - 1; i++)
            {
                long sum = f0 + f1 + f2;
                f0 = f1;
                f1 = f2;
                f2 = sum;
                triboSeq.Append(sum+ " ");
            }

            Console.WriteLine(triboSeq);
        }
    }
}
