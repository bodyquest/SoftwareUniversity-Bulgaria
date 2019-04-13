using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(" | ").ToArray();
            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < array.Length; i++)
            {
                string[] wordInfo = array[i].Split(": ");
                string word = wordInfo[0];
                string definition = wordInfo[1];

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                    words[word].Add(definition);
                }
                else
                {
                    words[word].Add(definition);
                }
            }

            var wordsToValidate = Console.ReadLine().Split(" | ").ToArray();
            for (int i = 0; i < wordsToValidate.Length; i++)
            {
                foreach (var word in words)
                {
                    if (word.Key == wordsToValidate[i])
                    {
                        Console.WriteLine($"{word.Key}:");
                        foreach (var def in word.Value.OrderByDescending(d => d.Length))
                        {
                            Console.WriteLine($" -{def}");
                        }
                    }
                }
            }

            string command = Console.ReadLine();
            if (command == "List")
            {
                foreach (var word in words.OrderBy(w => w.Key))
                {
                    Console.Write($"{word.Key} ");
                }
                Console.WriteLine();
            }
            else if (command == "End")
            {
                return;
            }

        }
    }
}
