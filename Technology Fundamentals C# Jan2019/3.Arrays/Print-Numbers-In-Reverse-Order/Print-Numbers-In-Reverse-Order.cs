using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Numbers_In_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int[] array = new int[num];

            for (int i = 0; i < num; i++)
            {
                int n = int.Parse(Console.ReadLine());
                array[num - i- 1] = n;
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
