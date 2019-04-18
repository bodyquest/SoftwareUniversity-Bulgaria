using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Matching_Brackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<int> expressionFinder = new Stack<int>(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    expressionFinder.Push(i);
                }
                if (input[i] == ')')
                {
                    int start = expressionFinder.Pop();
                    Console.WriteLine(input.Substring(start, i-start +1));
                }
            }
        }
    }
}  