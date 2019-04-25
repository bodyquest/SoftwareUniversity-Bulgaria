using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var sorted = array.Where(n => n % 2 == 0).Select(n => n).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(", ",  sorted));

        }
    }
}
 