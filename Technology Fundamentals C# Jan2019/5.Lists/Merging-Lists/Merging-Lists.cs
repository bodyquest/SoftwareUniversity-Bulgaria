using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> result = new List<int>();

            if (list.Count >= list2.Count)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    result.Add(list[i]);
                    result.Add(list2[i]);
                }
                for (int i = list2.Count; i < list.Count; i++)
                {
                    result.Add(list[i]);
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    result.Add(list[i]);
                    result.Add(list2[i]);
                }
                for (int i = list.Count; i < list2.Count; i++)
                {
                    result.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}