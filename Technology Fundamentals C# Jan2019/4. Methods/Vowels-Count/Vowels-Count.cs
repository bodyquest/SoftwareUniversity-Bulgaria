using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(PrintVoewlsCount(input)); ;

        }

        private static int PrintVoewlsCount(string input)
        {
            int sum = 0;
            string toLower = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                if (toLower[i] == 'a' || toLower[i] == 'e'|| toLower[i] == 'o' || toLower[i] == 'u' || toLower[i] == 'i' || toLower[i] == 'y')
                {
                    sum++;
                }
            }
            
            return sum;
        }
    }
}
