using System;
using System.Linq;

namespace Sum_Number
{
    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(", ")
                .Select(n => n.Trim())
                .Select(Parse)
                .ToArray();
            

            Console.WriteLine(array.Count());
            Console.WriteLine(array.Sum());
        }

        public static Func<string, int> Parse = n =>
        {
            int result = 0;
            if (int.TryParse(n, out result))
            {
                return result;
            }

            return 0;
        };
    }
}
