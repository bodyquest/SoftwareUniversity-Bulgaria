using System;
using System.Collections.Generic;
using System.Linq;

namespace EXRC_Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            Func<List<int>, List<int>> addFunc = x => x.Select(a => a+=1).ToList();
            Func<List<int>, List<int>> subtractFunc = x => x.Select(a => a-=1).ToList();
            Func<List<int>, List<int>> multiplyFunc = x => x.Select(a => a *= 2).ToList();
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            string input = Console.ReadLine();
            while (input!= "end")
            {
                if (input == "add")
                {
                    list = addFunc(list);
                }
                else if (input == "subtract")
                {
                    list = subtractFunc(list);
                }
                else if (input == "multiply")
                {
                    list = multiplyFunc(list);
                }
                else if (input == "print")
                {
                    print(list);
                }

                input = Console.ReadLine();
            }
        }
    }
}
