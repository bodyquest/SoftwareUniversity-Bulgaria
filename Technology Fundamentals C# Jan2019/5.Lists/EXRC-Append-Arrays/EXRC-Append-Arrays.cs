using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split('|').Reverse().ToList();

            var result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                List<string> temp = list[i].Split(' ').ToList();

                for (int j = 0; j < temp.Count; j++)
                {
                    if (!string.IsNullOrWhiteSpace(temp[j]))
                    {
                        result.Add(int.Parse(temp[j]));
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
