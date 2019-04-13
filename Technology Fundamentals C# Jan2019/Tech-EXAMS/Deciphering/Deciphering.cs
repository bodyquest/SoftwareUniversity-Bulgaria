using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Deciphering
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split("|").ToArray();
            var letters = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                char[] word = input[i].ToCharArray();
                for (int w = 0; w < word.Length; w++)
                {
                    word[w] -= (char)3;
                }
                input[i] = new string(word);
            }

            string inputString = string.Join("", input);
            bool isValidText = true;

            Regex isValid = new Regex(@"^[d-z#\{\}\| ]+$");
            for (int i = 0; i < inputString.Length; i++)
            {
                if (!isValid.IsMatch(inputString))
                {
                    isValidText = false;
                }
            }

            if (isValidText)
            {
                string letter1 = letters[0];
                string letter2 = letters[1];

                MatchCollection match = Regex.Matches(inputString, letter1);

                foreach (Match item in match)
                {
                    string replacement = letter2;
                    inputString = inputString.Replace(item.ToString(), replacement);
                }

                var list = inputString.Split("|");
                Console.WriteLine(string.Join(" ", list));
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
