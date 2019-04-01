using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Mixed_Up_Lists
{
    public static class ExtensionMethods
    {
        public static string Join<T>(this IEnumerable<T> self, string separator)

        {
            return String.Join(separator, self.Select(e => e.ToString()).ToArray());
        }
        ////////  Console.WriteLine(list.Join(" "));  ////////
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var list2 = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            var mixedList = new List<double>();

            double[] range = new double[2];
            double border1 = 0;
            double border2 = 0;
            if (list1.Count > list2.Count)
            {
                range[0] = list1[list1.Count - 2];
                range[1] = list1[list1.Count - 1];
                border1 = range[0];
                border2 = range[1];
                int list2Index = list2.Count - 1;
                for (int i = 0; i < list1.Count-2; i++)
                {
                    mixedList.Add(list1[i]);
                    mixedList.Add(list2[list2Index]);
                    if (list2Index == 0)
                    {
                        break;
                    }
                    list2Index--;
                }
            }
            else if (list1.Count < list2.Count)
            {
                range[0] = list2[0];
                range[1] = list2[1];
                border1 = range[0];
                border2 = range[1];
                int list2Index = list2.Count - 1;
                for (int i = 0; i < list2.Count; i++)
                {
                    mixedList.Add(list1[i]);
                    mixedList.Add(list2[list2Index]);
                    if (list2Index == 2)
                    {
                        break;
                    }
                    list2Index--;
                }
            }
            List<double> result = new List<double>();
            for (int i = 0; i < mixedList.Count; i++)
            {
                if (mixedList[i] > (Math.Min(border1, border2)) && mixedList[i] < (Math.Max(border1, border2)))
                {
                    result.Add(mixedList[i]);
                }
            }
            result.Sort();
            Console.WriteLine(result.Join(" "));
        }
    }
}
