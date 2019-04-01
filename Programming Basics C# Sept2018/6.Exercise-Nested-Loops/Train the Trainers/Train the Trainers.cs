using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_the_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string nameExam = String.Empty;
            double grades = 0;
            double sumGrades = 0;
            double avgGrade = 0;
            double finalGrade = 0;
            int count = 0;

            while (nameExam != "Finish")
            {
                nameExam = Console.ReadLine();
                if (nameExam == "Finish")
                {
                    break;
                }
                for (int juryGrades = 1; juryGrades <= n; juryGrades++)
                {
                    grades = double.Parse(Console.ReadLine());
                    sumGrades += grades;
                    
                }
                avgGrade = sumGrades / n;
                Console.WriteLine($"{nameExam} - {avgGrade:f2}.");
                finalGrade += avgGrade;
                count++;
                sumGrades = 0;
                
            }

            Console.WriteLine($"Student's final assessment is {finalGrade / count:f2}.");
        }
    }
}
