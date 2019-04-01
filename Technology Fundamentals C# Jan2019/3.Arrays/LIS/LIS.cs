using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS
{
    class Program
    {
        static void Main(string[] args)
        {
            var seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] len = new int[seq.Length];
            int[] prev = new int[seq.Length];

            int maxLen = 0;
            int lastIndex = -1;

            for (int x = 0; x < seq.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;
                for (int i = 0; i <= x-1; i++)
                {
                    if (seq[i] < seq[x] && len[i] + 1 > len[x])
                    {
                        len[x] = 1 + len[i];
                        prev[x] = i;
                    }
                }
                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            Console.WriteLine(string.Join(" ", RestoreLIS(seq, prev, lastIndex)));
        }

        public static int[] RestoreLIS (int[] seq, int[]prev, int lastIndex)
        {
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(seq[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            longestSeq.Reverse();

            return longestSeq.ToArray();
        }
    }
}
