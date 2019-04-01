using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = new List<int>();
            int sum = 0;
            for (int i = 0; i < list.Count/2; i++)
            {
                result.Add(list[i] + list[list.Count - 1 - i]);
                if ((i == (list.Count / 2)  - 1) && (list.Count % 2 != 0))
                {
                    result.Add(list[i+1]);
                }
            }

            if (list.Count == 1)
            {
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
            
        }
    }
}
