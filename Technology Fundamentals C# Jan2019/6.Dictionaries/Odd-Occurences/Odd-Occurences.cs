using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Occurences
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (var word in array)
            {
                string wordToLower = word.ToLower();
                if (dict.ContainsKey(wordToLower))
                {
                    dict[wordToLower]++;
                }
                else
                {
                    dict.Add(wordToLower, 1);
                }
            }

            foreach (var count in dict)
            {
                if (count.Value % 2 !=0)
                {
                    Console.Write(count.Key + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
