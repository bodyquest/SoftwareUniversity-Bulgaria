namespace Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var dict = new Dictionary<string, int>();

            using (var reader = new StreamReader("../../../../Resources/03.Word Count/words.txt", true))
            {
                List<string> words = new List<string>();

                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var wordsLine = line.Split(' ').ToArray();

                    for (int i = 0; i < wordsLine.Length; i++)
                    {
                        words.Add(wordsLine[i]);
                    }
                }

                foreach (var word in words)
                {
                    dict[word] = 0;
                }
            }

            using (var inputReader = new StreamReader("../../../../Resources/03.Word Count/text.txt"))
            {
                List<string> text = new List<string>();

                while (true)
                {
                    var line = inputReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var wordsLine = line.Split(' ').ToArray();
                    
                    for (int i = 0; i < wordsLine.Length; i++)
                    {
                        text.Add(wordsLine[i]);
                    }
                }

                string textToSearch = string.Join(" ", text);

                foreach (Match match in Regex.Matches(textToSearch, @"\w+"))
                {
                    string word = match.Value.ToLower();
                    if (dict.ContainsKey(word))
                    {
                        dict[word]++;
                    }
                }
            }

            using (var writer = new StreamWriter("../../../../Resources/03.Word Count/output.txt"))
            {
                foreach (var word in dict.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
