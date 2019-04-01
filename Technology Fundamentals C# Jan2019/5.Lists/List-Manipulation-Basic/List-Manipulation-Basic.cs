using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Manipulation_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(' ').ToArray();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "Add":
                        int numToAdd = int.Parse(command[1]); list.Add(numToAdd); break;
                    case "Remove":
                        int numToRemove = int.Parse(command[1]); list.Remove(numToRemove); break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(command[1]); list.RemoveAt(indexToRemove); break;
                    case "Insert":
                        int numberToInsert = int.Parse(command[1]);
                        int indexToInsert = int.Parse(command[2]);
                        list.Insert(indexToInsert, numberToInsert);
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
