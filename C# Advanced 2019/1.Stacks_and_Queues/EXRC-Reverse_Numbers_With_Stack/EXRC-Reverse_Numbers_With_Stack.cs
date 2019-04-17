using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Reverse_Numbers_With_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var stack = new Stack<int>(array);

            foreach (var item in stack)
            {
                Console.Write(item + " ");
            }
        }
    }
}
