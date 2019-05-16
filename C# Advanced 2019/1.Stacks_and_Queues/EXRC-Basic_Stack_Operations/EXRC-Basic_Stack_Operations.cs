using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arrayToRead = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int countToPush = array[0];
            int toPop = array[1];
            int lookFor = array[2];
            int minElement = int.MaxValue;

            var stack = new Stack<int>();

            for (int i = 0; i < countToPush; i++)
            {
                stack.Push(arrayToRead[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }
            if (stack.Contains(lookFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                foreach (var item in stack)
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
