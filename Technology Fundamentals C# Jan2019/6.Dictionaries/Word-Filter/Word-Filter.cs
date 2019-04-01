using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Filter
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            var filtered = array.Where(x => x.Length % 2 == 0).ToArray();
            Console.WriteLine(string.Join("\n", filtered));

        }
    }
}
