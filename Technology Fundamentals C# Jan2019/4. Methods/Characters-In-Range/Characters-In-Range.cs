using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters_In_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char one = char.Parse(Console.ReadLine());
            char two = char.Parse(Console.ReadLine());

            PrintCharsInRange(one, two);
        }

        private static void PrintCharsInRange(char one, char two)
        {
            // start - c; end - a
            if (two < one)
            {
                char temp = one;
                one = two;
                two = temp;

            }
            for (char i = (char)(one + 1); i < two; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
