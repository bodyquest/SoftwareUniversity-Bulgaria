using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Decimal_To_Binary_Converter
{
    class Program
    {
        static void Main()
        {
            // % 2 and push remainder in Stack
            // divide the num/2
            // pop all remainders or foreach them
            //------------------------------------

            int num = int.Parse(Console.ReadLine());
            Stack<int> binary = new Stack<int>();

            while (num > 0)
            {
                int bit = num % 2;
                binary.Push(bit);
                num /= 2;
            }

            foreach (var item in binary)
            {
                Console.Write(item);
            }
        }
    }
}
