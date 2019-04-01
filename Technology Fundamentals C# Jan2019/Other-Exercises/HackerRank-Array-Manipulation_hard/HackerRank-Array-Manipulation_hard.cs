using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_Array_Manipulation_hard
{
    class Program
    {
        static void Main(string[] args)
        {
            var nmParameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = nmParameters[0];
            int m = nmParameters[1];
            long[] array = new long[n];

            ////////////////////////////////////////////////////
            //var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int row = 0; row < m; row++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                uint a = uint.Parse(input[0]);
                uint b = uint.Parse(input[1]);
                long k = long.Parse(input[2]);
                for (uint i = a-1; i < b; i++)
                {
                    array[i] += k;
                }
                
            }

            long temp = 0;
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //Console.WriteLine(elapsedMs);
            ///////////////////////////////////////////////////
            Console.WriteLine(max.ToString());
        }
    }
}
