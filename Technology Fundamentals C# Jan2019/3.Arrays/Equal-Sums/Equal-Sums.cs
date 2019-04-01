using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            leftSum = 0;
            rightSum = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                rightSum += arr[j];
            }

            for (int k = 0; k < arr.Length; k++)
            {
                rightSum -= arr[k];
                if (rightSum == leftSum)
                {
                    Console.WriteLine(k);
                    return;
                }

                leftSum += arr[k];
            }

            Console.WriteLine("no");
        }
    }
}
