using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int first = arr[0];
                for (int j = 0; j < arr.Length -1; j++)
                {
                    arr[j] = arr[j + 1];
                    //int temp = arr[j];
                    //arr[j] = arr[arr.Length - 1];
                    //arr[arr.Length - 1] = temp;
                }

                arr[arr.Length - 1] = first;
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
