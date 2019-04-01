using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Even_And_Odd_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;
           

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumEven += array[i];
                }
                else if (array[i] % 2 != 0)
                {
                    sumOdd += array[i];
                }
            }

            int difference = sumEven - sumOdd;
            Console.WriteLine(difference);
        }
    }
}
