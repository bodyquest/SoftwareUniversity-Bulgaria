using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condense_Array_To_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            while (array.Length >1)
            {
                var condensed = new int[array.Length - 1];
                for (int j = 0; j < array.Length- 1; j++)
                {
                    condensed[j] = array[j] + array[j + 1];
                }
                array = new int[condensed.Length];
                for (int i = 0; i < condensed.Length; i++)
                {
                    array[i] = condensed[i];
                }
            }

            Console.WriteLine(array[0]);
        }
    }
}
