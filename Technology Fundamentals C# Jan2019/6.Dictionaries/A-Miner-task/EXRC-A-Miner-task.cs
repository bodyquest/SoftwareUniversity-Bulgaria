using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Miner_task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            while (input !="stop")
            {
                string commodity = input;
                int qty = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(commodity))
                {
                    dict[commodity] = qty;
                }
                else
                {
                    dict[commodity] += qty;
                }

                input = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
