using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split(' ').ToArray();
            var arr2 = Console.ReadLine().Split(' ').ToArray();

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr1.Length; j++)
                {
                    if (arr2[i] == arr1[j])
                    {
                        result.Append(arr2[i]);
                        if (i < arr1.Length -1)
                        {
                            result.Append(" ");
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
