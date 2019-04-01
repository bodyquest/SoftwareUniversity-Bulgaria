using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Negatives_And_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> toRemove = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    toRemove.Add(list[i]);
                }
            }
            foreach (var item in toRemove)
            {
                if (list.Contains(item))
                {
                    list.Remove(item);
                }
            }

            for (int i = 0; i < list.Count/2; i++)
            {
                int temp = list[i];
                list[i] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = temp;
            }

            if (list.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }
    }
}
