namespace EXRC_Word_Count
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
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();

            using (var wordReader = new StreamReader("../../../words.txt"))
            {
                List<string> words = new List<string>();
                while (true)
                {
                    string line = wordReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var lineOfWords = line.Split().ToArray();
                    for (int i = 0; i < lineOfWords.Length; i++)
                    {
                        words.Add(lineOfWords[i]);
                    }
                }

                foreach (var word in words)
                {
                    wordsDict[word] = 0;
                }
            }

            using (var textReader = new StreamReader("../../../text.txt"))
            {
                List<string> words = new List<string>();
                while (true)
                {
                    string line = textReader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var lineOfWords = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
                    for (int i = 0; i < lineOfWords.Length; i++)
                    {
                        words.Add(lineOfWords[i]);
                    }
                }

                string textToSearch = string.Join(" ", words);
                foreach (Match match in Regex.Matches(textToSearch, @"\w+"))
                {
                    string word = match.Value.ToLower();
                    if (wordsDict.ContainsKey(word))
                    {
                        wordsDict[word]++;
                    }
                }
            }

            var sortedDictionary = wordsDict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (var resultReader = new StreamReader("../../../expectedResult.txt"))
            {
                using (var writer = new StreamWriter("../../../actualResults.txt"))
                {
                    bool isSame = true;
                    string output = string.Empty;
                    foreach (var item in sortedDictionary)
                    {
                        output = $"{item.Key} - {item.Value}";
                        string line = resultReader.ReadLine();

                        if (output != line)
                        {
                            isSame = false;
                            break;
                        }
                    }

                    if (isSame)
                    {
                        //to do ?
                    }
                }
            }

            using (var writer = new StreamWriter("../../../actualResults.txt"))
            {
                foreach (var item in sortedDictionary)
                {
                    string output = $"{item.Key} - {item.Value}";
                    writer.WriteLine(output);
                }
            }
        }
    }
}
