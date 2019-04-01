using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    public static class ExtensionMethods
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
        //////////  list.Swap(index1, index2);  /////////

        public static string Join<T>(this IEnumerable<T> self, string separator)

        {
            return String.Join(separator, self.Select(e => e.ToString()).ToArray());
        }
        ////////  Console.WriteLine(list.Join(" "));  ////////

        public static int ToInt(this String input)
        {
            int result;
            if (!int.TryParse(input, out result))
            {
                result = 0;
            }
            return result;
        }
        //////////  CONVERT STRING to INT//////////////
        ////////  int num = array[0].ToInt();  ////////

        public static int SumDigits(this int input)
        {
            int sum = 0;
            while (input > 0)
            {
                var num = input % 10;
                sum = sum + num;
                input = input / 10;
            }
            return sum;
        }
        //////////  EXTRACT DIGITS from NUM and SUM THEM  //////////////
        ///////////////  int sum = input.SumDigits();  //////////////////

        public static string OnlyDigits(this string value)
        {
            return new string(value?.Where(c => char.IsDigit(c)).ToArray());
        }
        ///////////EXTRACT INT from STRING//////////////
        ////////  stringosano.OnlyDigits()   /////////

        public static void AddIfNotContains<T>(this IList<T> collection, T value)
        {
            if (value != null && !collection.Contains(value))
            {
                collection.Add(value);
            }
        }
        ///////////ADD if not contains//////////////
        ////////  list.AddIfNotContains(value)   /////////
    }

    class test2
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            array[0]

        }
    }
}
