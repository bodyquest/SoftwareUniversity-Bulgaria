using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr1 = new int[n];
            var arr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int one = array[0];
                int two = array[1];
                if (i % 2 == 0)
                {
                    arr1[i] = one;
                    arr2[i] = two;
                }
                else
                {
                    arr1[i] = two;
                    arr2[i] = one;
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
