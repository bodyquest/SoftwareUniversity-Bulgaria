using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.External_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int countPoor = 0;
            int countSatisfactory = 0;
            int countGood = 0;
            int countVeryGood = 0;
            int countExcellent = 0;

            for (int scores = 1; scores <= n; scores++)
            {
               double marks = double.Parse(Console.ReadLine());
                if (marks >= 0 && marks <=22.5)
                {
                    countPoor++;
                }
                if (marks > 22.5 && marks <= 40.5)
                {
                    countSatisfactory++;
                }
                if (marks > 40.5 && marks <= 58.5)
                {
                    countGood++;
                }
                if (marks > 58.5 && marks <= 76.5)
                {
                    countVeryGood++;
                }
                if (marks > 76.5 && marks <= 100)
                {
                    countExcellent++;
                }
            }

            Console.WriteLine($"{(double)countPoor/n *100:f2}% poor marks");
            Console.WriteLine($"{(double)countSatisfactory / n * 100:f2}% satisfactory marks");
            Console.WriteLine($"{(double)countGood / n * 100:f2}% good marks");
            Console.WriteLine($"{(double)countVeryGood / n * 100:f2}% very good marks");
            Console.WriteLine($"{(double)countExcellent / n * 100:f2}% excellent marks");
        }
    }
}
