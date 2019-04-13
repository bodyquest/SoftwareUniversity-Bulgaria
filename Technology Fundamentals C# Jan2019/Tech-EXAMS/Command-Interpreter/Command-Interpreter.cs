using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Command_Interpreter
{
    public static class ShiftList
    {
        public static List<T> ShiftLeft<T>(this List<T> list, int shiftBy)
        {
            if (list.Count <= shiftBy)
            {
                return list;
            }

            var result = list.GetRange(shiftBy, list.Count - shiftBy);
            result.AddRange(list.GetRange(0, shiftBy));
            return result;
        }

        public static List<T> ShiftRight<T>(this List<T> list, int shiftBy)
        {
            if (list.Count <= shiftBy)
            {
                return list;
            }

            var result = list.GetRange(list.Count - shiftBy, shiftBy);
            result.AddRange(list.GetRange(0, list.Count - shiftBy));
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //READY
            var array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(x=>x.Length > 0).ToList();
            ///////

            var command = Console.ReadLine().Split(' ').ToArray();
            while (!command[0].Equals("end"))
            {
                string toDo = command[0];
                if (toDo.Equals("reverse"))
                {
                    int startIndex = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    if (startIndex >= 0 && startIndex <= array.Count-1-count && count >=0 && count<= array.Count)
                    {
                        var reversed = array.Skip(startIndex).Take(count).Reverse();
                        var left = array.Take(startIndex);
                        var right = array.Skip(startIndex + count);
                        //array = left.Concat(reversed).Concat(right).ToList();
                        var all = left.Concat(reversed).Concat(right);
                        var index = 0;
                        foreach (var item in all.ToList())
                        {
                            array[index++] = item;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (toDo.Equals("sort"))
                {
                    int startIndex = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    if (startIndex >= 0 && startIndex <= array.Count - 1 - count && count >= 0 && count <= array.Count)
                    {
                        var sorted = array.Skip(startIndex).Take(count).OrderByDescending(x => x[0]).ToArray();
                        var left = array.Take(startIndex).ToArray();
                        var right = array.Skip(left.Length + sorted.Length).ToArray();
                        array = left.Concat(sorted).Concat(right).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }

                }
                else if (toDo.Equals("rollLeft"))
                {
                    BigInteger num = BigInteger.Parse(command[1]);
                    int count = 0;
                    if (num > array.Count)
                    {
                        num = num %= array.Count;
                    }
                    count = (int)(num);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        array = array.ShiftLeft(count);
                    }
                }
                else if (toDo.Equals("rollRight"))
                {
                    BigInteger num = BigInteger.Parse(command[1]);
                    int count = 0;
                    if (num > array.Count)
                    {
                        num = num %= array.Count;
                    }
                    count = (int)(num);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        array = array.ShiftRight(count);
                    }
                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            //READY
            Console.Write("[");
            Console.Write(string.Join(", ", array));
            Console.WriteLine("]");
        }
    }
}
