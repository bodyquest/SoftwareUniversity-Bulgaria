using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    public class PrintEvenNumbers
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue evenNums = new Queue();

            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    evenNums.Enqueue(item);
                }
            }

            while(evenNums.Count > 0)
            {
                int num = int.Parse(evenNums.Dequeue().ToString());
                Console.Write("{0}{1}", num, evenNums.Count == 0? "": ", " );
            }

            Console.WriteLine();
        }
    }
}
