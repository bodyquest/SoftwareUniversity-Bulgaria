using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int maxElement = int.MinValue;
            int minElement = int.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (array.Length == 2)
                {
                    stack.Push(array[1]);
                }
                else
                {
                    if (array[0] == 2 && stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else if (array[0] == 3 && stack.Count > 0)
                    {
                        foreach (var item in stack)
                        {
                            if (item > maxElement)
                            {
                                maxElement = item;
                            }
                        }

                        Console.WriteLine(maxElement);
                    }
                    else if (array[0] == 4 && stack.Count > 0)
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

            while (stack.Count > 0)
            {
                int num = int.Parse(stack.Pop().ToString());
                Console.Write("{0}{1}", num, stack.Count == 0 ? "" : ", ");
            }

            Console.WriteLine();
        }
    }
}
