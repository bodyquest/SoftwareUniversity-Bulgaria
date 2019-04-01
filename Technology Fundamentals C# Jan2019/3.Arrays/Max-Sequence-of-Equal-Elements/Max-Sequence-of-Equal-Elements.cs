using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length = 1;
            int maxLength = 1;
            int start = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i-1])
                {
                    length++;
                    if (length > maxLength)
                    {
                        start = i - length + 1;
                        maxLength = length;
                    }
                }
                else
                {
                    length = 1;
                }
            }

            for (int i = start; i <= start + maxLength - 1; i++)
            {
                Console.Write("{0}{1}", arr[i], i == start + maxLength ? "": " ");
            }
            Console.WriteLine();
        }
    }
}
