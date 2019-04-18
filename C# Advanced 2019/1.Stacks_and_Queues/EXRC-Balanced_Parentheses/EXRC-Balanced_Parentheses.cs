using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stackOfParentheses = new Stack<char>();

            char[] opening = new char[] {'(', '[', '{' };
            bool isValid = true;
            for (int i = 0; i < input.Length; i++)
            {
                char parentheses = input[i];
                if (opening.Contains(parentheses))
                {
                    stackOfParentheses.Push(parentheses);
                    continue;
                }

                if (stackOfParentheses.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stackOfParentheses.Peek() == '(' && parentheses == ')')
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '[' && parentheses == ']')
                {
                    stackOfParentheses.Pop();
                }
                else if (stackOfParentheses.Peek() == '{' && parentheses == '}')
                {
                    stackOfParentheses.Pop();
                }

            }

            if (stackOfParentheses.Count == 0 && isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
