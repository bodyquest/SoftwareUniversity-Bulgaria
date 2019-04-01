using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string word1 = Console.ReadLine();
                string word2 = Console.ReadLine();

                if (!synonyms.ContainsKey(word1))
                {
                    synonyms[word1] = new List<string>();
                }
                if (synonyms.ContainsKey(word1) && !synonyms[word1].Contains(word2))
                {
                    synonyms[word1].Add(word2);
                }
            }

            foreach (var item in synonyms)
            {
                Console.Write($"{item.Key} - ");
                Console.WriteLine(string.Join(", ", item.Value));
            }
        }
    }
}
