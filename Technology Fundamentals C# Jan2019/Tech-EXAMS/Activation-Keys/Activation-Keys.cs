

namespace Activation_Keys
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('&').ToArray();
            Regex game = new Regex(@"([A-Za-z0-9]{16}\b)|([A-Za-z0-9]{25}\b)");
            var list = new List<string>();
            var finalList = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string key = input[i];
                char[] k = key.ToCharArray();
                if (game.IsMatch(key) && key.Length == 16)
                {
                    ConvertDigit(k);
                    key = new string(k);
                    TokenizeIf16(list, key);
                    finalList.Add(string.Join("", list));
                    list.Clear();
                }
                else if (game.IsMatch(key) && key.Length == 25)
                {
                    ConvertDigit(k);
                    key = new string(k);
                    TokenizeIf25(list, key);
                    finalList.Add(string.Join("", list));
                    list.Clear();
                }
            }

            //TO PRINT
            Console.WriteLine(string.Join(", ", finalList));
        }

        private static void TokenizeIf16(List<string> list, string key)
        {
            for (int token = 0; token < key.Length - 3; token += 4)
            {
                string item = key.Substring(token, 4).ToUpper();

                if (token == key.Length - 4)
                {
                    list.Add(item);
                }
                else
                {
                    list.Add(item + "-");
                }
            }
        }

        private static void TokenizeIf25(List<string> list, string key)
        {
            for (int token = 0; token < key.Length - 4; token += 5)
            {
                string item = key.Substring(token, 5).ToUpper();
                if (token == key.Length - 5)
                {
                    list.Add(item);
                }
                else
                {
                    list.Add(item + "-");
                }
            }
        }

        private static void ConvertDigit(char[] k)
        {
            for (int ch = 0; ch < k.Length; ch++)
            {
                if (Char.IsDigit(k[ch]))
                {
                    k[ch] = (char)(48 + (9 - (k[ch] - 48)));
                }
            }
        }

    }
}
