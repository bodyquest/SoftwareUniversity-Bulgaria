using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_TriFunction
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Console.ReadLine().Split(' ').Select(x => x.ToCharArray().Select(y => (int)y).Sum() >= n).FirstOrDefault());


        }
    }
}
