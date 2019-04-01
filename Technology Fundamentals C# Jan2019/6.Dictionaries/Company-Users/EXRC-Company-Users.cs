using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var array = input.Split(new char[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = array[0];
                string employee = array[1];
                if (!dict.ContainsKey(company))
                {
                    dict[company] = new List<string>();
                    dict[company].Add(employee);
                }
                else
                {
                    if (!dict[company].Contains(employee))
                    {
                        dict[company].Add(employee);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in dict.OrderBy(x=>x.Key))
            {
                string company = item.Key;
                List<string> ids = item.Value;

                Console.WriteLine($"{company}");
                foreach (var id in ids)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
