using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_LadyBugs
{
    class Program
    {
        static void Main()
        {
            int[] bugField = new int[int.Parse(Console.ReadLine())];
            int[] bugIndex = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<string> command = Console.ReadLine().Split(' ').ToList();

            for (int i = 0; i < bugIndex.Length; i++)
            {
                if (bugIndex[i] >= 0 && bugIndex[i] < bugField.Length)
                {
                    bugField[bugIndex[i]] = 1;
                }
            }

            while (command[0] != "end")
            {
                int startIndex = int.Parse(command[0]);
                int flyLength = int.Parse(command[2]);
                int endIndex = 0;

                if (startIndex >= 0 && startIndex <= bugField.Length - 1 && bugField[startIndex] == 1) //we have a ladybug found in the field
                {
                    bugField[startIndex] = 0;

                    if (command[1] == "right")
                    {
                        endIndex = startIndex + flyLength;
                        while (endIndex < bugField.Length)
                        {
                            if (bugField[endIndex] == 0)
                            {
                                bugField[endIndex] = 1;
                                break;
                            }
                            endIndex += flyLength;
                        }
                    }
                    else if (command[1] == "left")
                    {
                        endIndex = startIndex - flyLength;
                        while (endIndex >= 0)
                        {
                            if (bugField[endIndex] == 0)
                            {
                                bugField[endIndex] = 1;
                                break;
                            }
                            endIndex -= flyLength;
                        }
                    }
                }
                command = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine(string.Join(" ", bugField));
        }
    }
}
