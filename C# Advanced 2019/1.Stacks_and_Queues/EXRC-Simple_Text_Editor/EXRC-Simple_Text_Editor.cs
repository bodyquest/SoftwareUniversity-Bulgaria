using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> textEditor = new Queue<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                int num = int.Parse(input[0]);
                if (num == 4)
                {

                }
                else
                {
                    if (num == 1)
                    {
                        string text = input[1];
                        textEditor.Enqueue(text);
                    }
                    else if(num == 2)
                    {
                        int count = int.Parse(input[1]);
                        for (int j = 0; j < count; j++)
                        {
                            textEditor.Dequeue();
                        }
                    }
                    else if (num == 3)
                    {

                    }
                }

            }
            

        }
    }
}
