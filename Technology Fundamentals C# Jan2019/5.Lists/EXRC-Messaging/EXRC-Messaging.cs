using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Messaging
{
    public static class ExtensionMethods
    {
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
        public static string Join<T>(this IEnumerable<T> self, string separator)

        {
            return String.Join(separator, self.Select(e => e.ToString()).ToArray());
        }
        ////////  Console.WriteLine(list.Join(" "));  ////////
    }

    class Program
    {
        static void Main()
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            List<string> message = new List<string>();
            message.AddRange(input.Select(c => c.ToString()));

            List<string> output = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                int sum = array[i].SumDigits();
                if (sum > message.Count)
                {
                    sum %= message.Count;
                }

                output.Add(message[sum]);
                message.RemoveAt(sum);
            }
            Console.WriteLine(output.Join(""));
        }
    }
}
