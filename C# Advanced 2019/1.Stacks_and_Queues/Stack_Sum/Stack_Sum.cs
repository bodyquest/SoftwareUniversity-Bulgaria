using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    public class StackSum
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            string[] line = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int number = 0;
            while (line[0]?.ToLower() != "end")
            {
                if (int.TryParse(line[0], out number))
                {
                    foreach (var item in line)
                    {
                        stack.Push(int.Parse(item));
                    }
                }
                else
                {
                    string command = line[0];
                    switch (command)
                    {
                        case "add":
                            for (int i = 1; i < line.Length; i++)
                            {
                                stack.Push(int.Parse(line[i]));
                            }
                            break;
                        case "remove":
                            int count = int.Parse(line[1]);
                            if (count > stack.Count)
                            {
                                break;
                            }
                            for (int i = 0; i < count; i++)
                            {
                                stack.Pop();
                            }
                            break;
                        default:
                            break;
                    }
                }

                line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
