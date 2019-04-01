using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(' ').ToArray();

            while (command[0] != "End")
            {
                ExecuteCommands(list, command);

                command = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void ExecuteCommands(List<int> list, string[] command)
        {
            if (command[0] == "Add")
            {
                list.Add(int.Parse(command[1]));
            }
            else if (command[0] == "Insert")
            {
                if (int.Parse(command[2]) > list.Count - 1 || int.Parse(command[2]) < 0)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

            }
            else if (command[0] == "Remove")
            {
                if (int.Parse(command[1]) > list.Count - 1 || int.Parse(command[1]) < 0)
                {
                    Console.WriteLine("Invalid index");
                }
                else
                {
                    list.RemoveAt(int.Parse(command[1]));
                }

            }
            else if (command[0] == "Shift")
            {
                if (command[1] == "right")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        list.Insert(0, list[list.Count - 1]);
                        list.RemoveAt(list.Count - 1);
                    }
                }
                else if (command[1] == "left")
                {
                    for (int i = 0; i < int.Parse(command[2]); i++)
                    {
                        list.Add(list[0]);
                        list.Remove(list[0]);
                    }
                }
            }
        }
    }
}
