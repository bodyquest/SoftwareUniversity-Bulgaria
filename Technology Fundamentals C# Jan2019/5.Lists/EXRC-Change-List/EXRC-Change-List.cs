using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var command = Console.ReadLine().Split(' ').ToArray();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    list.RemoveAll(num => num == int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    list.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
