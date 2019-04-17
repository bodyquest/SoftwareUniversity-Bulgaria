using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Calculate_Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<long>();
            var queue = new Queue<long>();
            int n = int.Parse(Console.ReadLine());

            queue.Enqueue(n);
            list.Add(n);
            for (int i = 0; i < 17; i++)
            {
                
                long currentN = queue.Dequeue();
                long a = currentN + 1;
                long b = currentN * 2 + 1;
                long c = currentN + 2;
                queue.Enqueue(a);
                queue.Enqueue(b);
                queue.Enqueue(c);

                list.Add(a);
                list.Add(b);
                list.Add(c);
            }
            Console.WriteLine(string.Join(" ", list.Take(50)));
        }
    }
}
