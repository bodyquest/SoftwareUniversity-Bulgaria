using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXRC_Take_Skip_Rope
{
    public static class ExtensionMethods
    {
        public static string OnlyDigits(this string value)
        {
            return new string(value?.Where(c => char.IsDigit(c)).ToArray());
        }
        ///////////EXTRACT INT from STRING//////////////
        ////////  stringosano.OnlyDigits()   /////////

        public static string GetWithoutDigits(this string value)
        {
            return new string(value?.Where(c => !char.IsDigit(c)).ToArray());
        }
        ///////////EXTRACT INT from STRING//////////////
        ////////  stringosano.OnlyDigits()   /////////
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string noDigits = input.GetWithoutDigits();
            List<string> nonDigitsList = new List<string>();
            nonDigitsList.AddRange(noDigits.Select(c => c.ToString()));

            string digits = input.OnlyDigits();
            List<int> digitList = new List<int>();
            digitList.AddRange(digits.Select(c => c.ToString()).Select(int.Parse));

            List<int> take = new List<int>();
            List<int> skip = new List<int>();
            for (int i = 0; i < digitList.Count; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    take.Add(digitList[i]);
                }
                else if (i % 2 != 0)
                {
                    skip.Add(digitList[i]);
                }
            }
            StringBuilder result = new StringBuilder();
            int takeCount = 0;
            int skipCount = 0;
            for (int i = 0; i < take.Count; i++)
            {
                takeCount = take[i];
                for (int j = skipCount; j < skipCount + takeCount; j++)
                {
                    if (j < nonDigitsList.Count)
                    {
                        result.Append(nonDigitsList[j]);
                    }
                    else if (j >= nonDigitsList.Count)
                    {
                        break;
                    }
                    
                }
                skipCount += skip[i] + take[i];
            }

            Console.WriteLine(result);
        }
    }
}
