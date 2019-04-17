using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arrayToRead = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countToAdd = array[0];
            int toRemove = array[1];
            int lookFor = array[2];
            int minElement = int.MaxValue;

            var queue = new Queue<int>();

            for (int i = 0; i < countToAdd; i++)
            {
                queue.Enqueue(arrayToRead[i]);
            }
            for (int i = 0; i < toRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (queue.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in queue)
                {
                    if (item < minElement)
                    {
                        minElement = item;
                    }
                }

                Console.WriteLine(minElement);
            }
        }
    }
}
