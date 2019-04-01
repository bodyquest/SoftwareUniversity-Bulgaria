using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(' ').ToArray();
            int count = 0;

            while (command[0] != "end")
            {
                PrintIfContains(list, command);
                PrintIfEven(list, command);
                PrintIfOdd(list, command);
                PrintSum(list, command);
                FilterElements(list, command);

                switch (command[0])
                {
                    case "Add":
                        int numToAdd = int.Parse(command[1]); list.Add(numToAdd); count++; break;
                    case "Remove":
                        int numToRemove = int.Parse(command[1]); list.Remove(numToRemove);count++; break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(command[1]); list.RemoveAt(indexToRemove); count++; break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsert = int.Parse(command[2]);
                        list.Insert(indexToInsert, numberToInsert); count++;
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            if (count> 0)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        private static void FilterElements(List<int> list, string[] command)
        {
            if (command[0] == "Filter")
            {
                if (command[1] == ">")
                {
                    for (int i = 0; i < list.Count; i++)
                    {

                        if (list[i] > int.Parse(command[2]))
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (command[1] == ">=")
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] >= int.Parse(command[2]))
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (command[1] == "<")
                {
                    for (int i = 0; i < list.Count; i++)
                    {

                        if (list[i] < int.Parse(command[2]))
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
                else if (command[1] == "<=")
                {
                    for (int i = 0; i < list.Count; i++)
                    {

                        if (list[i] <= int.Parse(command[2]))
                        {
                            Console.Write(list[i] + " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        private static void PrintSum(List<int> list, string[] command)
        {
            if (command[0] == "GetSum")
            {
                int sum = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    sum += list[i];
                }
                Console.WriteLine(sum);
            }
        }

        private static void PrintIfOdd(List<int> list, string[] command)
        {
            if (command[0] == "PrintOdd")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] % 2 != 0)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintIfEven(List<int> list, string[] command)
        {
            if (command[0] == "PrintEven")
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] % 2 == 0)
                    {
                        Console.Write(list[i] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintIfContains(List<int> list, string[] command)
        {
            if (command[0] == "Contains")
            {
                int contains = int.Parse(command[1]);
                if (list.Contains(contains))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No such number");
                }
            }
        }
    }
}

