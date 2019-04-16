using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Strings
{
    class Program
    {
        static void Main()
        {
            Stack<char> stringReverser = new Stack<char>();

            string input = Console.ReadLine();

            foreach (var ch in input)
            {
                stringReverser.Push(ch);
            }

            while (stringReverser.Count > 0)
            {
                Console.Write(stringReverser.Pop());
            }
            Console.WriteLine();
        }
    }
}
