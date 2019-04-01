using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string nameExam = String.Empty;
            double grades = 0;
            double sumGrades = 0;
            double avgFinalgrade = 0;

            while (nameExam != "Finish")
            {
                nameExam = Console.ReadLine();
                for (int juryGrades = 1; juryGrades <= n; juryGrades++)
                {
                    grades = double.Parse(Console.ReadLine());
                    sumGrades += grades;
                    avgFinalgrade += sumGrades / n;
                }
                Console.WriteLine($"{nameExam} - {sumGrades / n}.");
                sumGrades = 0;
            }
            Console.WriteLine($"Student's final assessment is {avgFinalgrade / n}.");
        }
    }
}
