using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class SimpleCalculator
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();

            Stack<string> result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                int first = int.Parse(result.Pop());
                string operand = result.Pop();
                int second = int.Parse(result.Pop());

                switch (operand)
                {
                    case "+":
                        result.Push((first + second).ToString());
                        break;
                    case "-":
                        result.Push((first - second).ToString());
                        break;
                    default:
                        result.Push(0.ToString());
                        break;
                }
            }

            Console.WriteLine(result.Pop());
        }
    }
}
