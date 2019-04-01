using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder reversed = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                reversed.Append(input[input.Length - 1 - i]);
            }

            Console.WriteLine(reversed);
        }
    }
}
