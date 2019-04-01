using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            ValidatePalindrome(input);
        }

        private static void ValidatePalindrome(string input)
        {
            while (input != "END")
            {
                string rev = string.Empty;
                StringBuilder reversed = new StringBuilder();

                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversed.Append(input[i]);
                }
                if (reversed.ToString() == input)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

                input = Console.ReadLine();
            }
        }
    }
}
