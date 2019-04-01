using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            var field = new int[fieldSize];
            var positions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i]>=0 && positions[i] < field.Length)
                {
                    int bugIndex = positions[i];
                    field[bugIndex] = 1;
                }
                
            }

            var command = Console.ReadLine().Split(' ').ToArray();
           
            while (command[0] != "end")
            {
                int bugIndex = int.Parse(command[0]);
                int endIndex = 0;
                string direction = command[1];
                int distance = int.Parse(command[2]);
                int shift = bugIndex + distance;

                if(bugIndex >= 0 && bugIndex <= field.Length -1 && field[bugIndex] == 1)
                {
                    field[bugIndex] = 0;
                    if (direction == "right")
                    {
                        endIndex = bugIndex + distance;
                        while (endIndex < field.Length)
                        {
                            if (field[endIndex] == 0)
                            {
                                field[endIndex] = 1;
                                break;
                            }
                            endIndex += distance;
                        }
                    }

                    else if (direction == "left")
                    {
                        endIndex = bugIndex - distance;
                        while (endIndex >= 0)
                        {
                            if (field[endIndex] == 0)
                            {
                                field[endIndex] = 1;
                                break;
                            }
                            endIndex -= distance;
                        }

                    }
                }
                command = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
