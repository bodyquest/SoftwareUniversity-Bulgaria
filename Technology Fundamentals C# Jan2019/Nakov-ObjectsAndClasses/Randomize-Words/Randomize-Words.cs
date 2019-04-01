using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ').ToArray();
            var shuffledWords = new List<string>();
            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int newIndex = rnd.Next(0, shuffledWords.Count + 1);
                shuffledWords.Insert(newIndex, words[i]);
            }

            foreach (var item in shuffledWords)
            {
                Console.WriteLine(item);
            }
        }
    }
}
