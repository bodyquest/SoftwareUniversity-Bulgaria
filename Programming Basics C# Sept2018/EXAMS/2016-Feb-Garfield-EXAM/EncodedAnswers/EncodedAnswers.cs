using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodedAnswers
{
    class EncodedAnswers
    {
        static void Main(string[] args)
        {
            int questions = int.Parse(Console.ReadLine());
            string result = String.Empty;
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;
            string input = String.Empty;

            for (int i = 1; i <= questions; i++)
            {
                uint num = uint.Parse(Console.ReadLine());
                if (num % 4 == 0)
                {
                    input = "a";
                    countA++;
                }
                else if (num % 4 == 1)
                {
                    input = "b";
                    countB++;
                }
                else if (num % 4 == 2)
                {
                    input = "c";
                    countC++;
                }
                else if (num % 4 == 3)
                {
                    input = "d";
                    countD++;
                }
                result += input + ' ';
            }
            Console.WriteLine(result);
            Console.WriteLine($"Answer A: {countA}");
            Console.WriteLine($"Answer B: {countB}");
            Console.WriteLine($"Answer C: {countC}");
            Console.WriteLine($"Answer D: {countD}");
        }
    }
}
