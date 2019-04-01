using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_SoftUni_Course_Planning
{
    public static class ExtensionMethods
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }

    class Program
    {
        static void Main()
        {
            var schedule = Console.ReadLine().Split(", ").ToList();


            while (true)
            {
                string command = Console.ReadLine();
                if (command == "course start")
                {
                    break;
                }
                else
                {
                    var commandArr = command.Split(':').ToArray();
                    if (commandArr[0] == "Add")
                    {
                        if (!schedule.Contains(commandArr[1]))
                        {
                            schedule.Add(commandArr[1]);
                        }
                    }
                    else if (commandArr[0] == "Insert")
                    {
                        if (!schedule.Contains(commandArr[1]))
                        {
                            schedule.Insert(int.Parse(commandArr[2]), commandArr[1]);
                        }
                    }
                    else if (commandArr[0] == "Remove")
                    {
                        if (schedule.Contains(commandArr[1]))
                        {
                            schedule.Remove(commandArr[1]);
                            if (schedule.Contains($"{commandArr[1]}-Exercise"))
                            {
                                schedule.Remove($"{commandArr[1]}-Exercise");
                            }
                        }
                    }
                    else if (commandArr[0] == "Swap")
                    {
                        if (schedule.Contains(commandArr[1]) && schedule.Contains(commandArr[2]))
                        {
                            //int index1 = schedule.IndexOf(commandArr[1]);
                            //int index2 = schedule.IndexOf(commandArr[2]);
                            /////////////////////////////////////////////////////////////////////
                            schedule.Swap(schedule.IndexOf(commandArr[1]), schedule.IndexOf(commandArr[2]));
                            /////////////////////////////////////////////////////////////////////
                            
                            ///////////  SWAP Exercises if they exist /////////////
                            if (schedule.Contains($"{commandArr[1]}-Exercise") && !schedule.Contains($"{commandArr[2]}-Exercise")) // IF ONLY EXERCISE 1 Exists
                            {
                                schedule.Remove($"{commandArr[1]}-Exercise");
                                int newIndex = schedule.IndexOf(commandArr[1]);
                                schedule.Insert(newIndex +1, $"{commandArr[1]}-Exercise");
                            }
                            else if (schedule.Contains($"{commandArr[2]}-Exercise") && !schedule.Contains($"{commandArr[1]}-Exercise")) // IF ONLY EXERCISE 2 Exists
                            {
                                schedule.Remove($"{commandArr[2]}-Exercise");
                                int newIndex = schedule.IndexOf(commandArr[2]);
                                schedule.Insert(newIndex +1, $"{commandArr[2]}-Exercise");
                            }
                            else if (schedule.Contains($"{commandArr[1]}-Exercise") && schedule.Contains($"{commandArr[2]}-Exercise")) // IF BOTH EXERCISES Exist
                            {
                                schedule.Swap(schedule.IndexOf($"{commandArr[1]}-Exercise"), schedule.IndexOf($"{commandArr[2]}-Exercise"));
                            }
                        }
                    }
                    else if (commandArr[0] == "Exercise")
                    {
                        if (schedule.Contains(commandArr[1]) && !schedule.Contains($"{commandArr[1]}-Exercise"))
                        {
                            schedule.Insert(schedule.IndexOf(commandArr[1]) +1, $"{commandArr[1]}-Exercise");
                        }
                        else if (!schedule.Contains(commandArr[1]))
                        {
                            schedule.Add(commandArr[1]);
                            schedule.Add($"{commandArr[1]}-Exercise");
                        }
                    }
                }
            }

            int count = 1;
            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{count}.{schedule[i]}");
                count++;
            }
        }
    }
}
