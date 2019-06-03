namespace EXRC_Predicate_For_Names
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').ToArray();
            List<string> list = new List<string>();

            Func<string[], string[]> nameFilter = arr => arr.Where(x => x.Length <= n).ToArray();
            Action<string[]> print = arr =>
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            };

            print(nameFilter(array));
        }
    }
}
