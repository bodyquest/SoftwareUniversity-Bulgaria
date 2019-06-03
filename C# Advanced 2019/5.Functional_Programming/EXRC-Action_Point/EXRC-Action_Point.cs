using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Action_Point
{
    class Program
    {
        static void Main()
        {
            var collection = Console.ReadLine().Split(' ').ToArray();

            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, collection));
            print(collection);
        }
    }
}
