using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Count_Chars_In_A_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] array = input.ToCharArray();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                {
                    dict[array[i]] = 1;
                }
                else
                {
                    dict[array[i]]++;
                }
            }

            foreach (var item in dict)
            {
                if (item.Key != ' ')
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }
    }
}
