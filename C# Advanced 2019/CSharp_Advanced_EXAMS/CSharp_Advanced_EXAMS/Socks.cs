namespace Socks
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            var leftSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rightSocks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> pairs = new List<int>();

            Stack<int> lefties = new Stack<int>(leftSocks);
            Queue<int> righties = new Queue<int>(rightSocks);

            int leftSock = 0;
            int rightSock = 0;

            while (true)
            {
                if (lefties.Count >0 && righties.Count > 0)
                {
                    leftSock = lefties.Peek();
                    rightSock = righties.Peek();

                    if (leftSock > rightSock)
                    {
                        pairs.Add(leftSock + rightSock);
                        lefties.Pop();
                        righties.Dequeue();
                    }
                    else if (leftSock < rightSock)
                    {
                        lefties.Pop();
                    }
                    else
                    {
                        righties.Dequeue();
                        int incremented = lefties.Pop() + 1;
                        lefties.Push(incremented);
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
