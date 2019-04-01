using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Academy
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!dict.ContainsKey(student))
                {
                    dict[student] = new List<double>();
                    dict[student].Add(grade);
                }
                else
                {
                    dict[student].Add(grade);
                }
            }
            //order by descending and filter items by >= 4.50
            dict = dict.OrderByDescending(x => x.Value.Average()).Where(x=>x.Value.Average() >= 4.50).ToDictionary(x => x.Key, y => y.Value);
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
