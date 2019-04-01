using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length- 1; i++)
            {
                int num = arr[i];
                for (int j = i+1; j < arr.Length; j++)
                {
                    int right = arr[j];
                    if (num <= right)
                    {
                        break;
                    }
                    else if (j == arr.Length-1)
                    {
                        Console.Write(num + " ");
                    }
                }
            }
            Console.WriteLine(arr[arr.Length-1]);
        }
    }
}
