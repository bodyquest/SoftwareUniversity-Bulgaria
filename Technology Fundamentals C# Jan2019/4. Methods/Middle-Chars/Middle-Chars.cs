using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middle_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            PrintMiddleChars(str);
        }

        private static void PrintMiddleChars (string str)
        {
            if (str.Length % 2 == 0)
            {
                //1234
                Console.WriteLine($"{str[str.Length/2 -1]}{str[str.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{str[str.Length/2]}");
            }
        }
    }
}
