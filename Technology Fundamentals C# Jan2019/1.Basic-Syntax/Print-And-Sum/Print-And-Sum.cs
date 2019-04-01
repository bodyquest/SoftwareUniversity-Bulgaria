using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                result.Append(i + " ");
                sum += i;
            }

            Console.WriteLine(result);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
