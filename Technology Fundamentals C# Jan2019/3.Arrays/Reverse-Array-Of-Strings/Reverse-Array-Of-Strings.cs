using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array_Of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            var arrayResult = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayResult[array.Length - i - 1] = array[i];
            }

            Console.WriteLine(string.Join(" ", arrayResult));
        }
    }
}
