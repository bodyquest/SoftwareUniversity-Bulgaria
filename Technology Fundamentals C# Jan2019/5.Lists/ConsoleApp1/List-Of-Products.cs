using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();
                list.Add(product);
            }

            list.Sort();
            int count = 1;
            foreach (var item in list)
            {
                Console.WriteLine($"{count}.{item}");
                count++;
            }

        }
    }
}
