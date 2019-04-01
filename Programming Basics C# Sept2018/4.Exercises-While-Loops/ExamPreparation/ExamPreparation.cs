using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class ExamPreparation
    {
        static void Main(string[] args)
        {
            int poorGradesLimit = int.Parse(Console.ReadLine());
            string last = String.Empty;
            double sum = 0;
            int count = 0;
            int countPoor = 0;
            while (true)
            {
                string problem = Console.ReadLine();
                
                if (problem != "Enough")
                {
                    last = problem;
                }
                if (problem == "Enough")
                {
                    Console.WriteLine($"Average score: {sum / count:f2}");
                    Console.WriteLine($"Number of problems: {count}");
                    Console.WriteLine($"Last problem: {last}");
                    break;
                }
                double grade = double.Parse(Console.ReadLine());
                count++;
                sum += grade;
                //string last = String.Empty;
                //if (problem != "Enough")
                //{
                //    last = problem;
                //}
                //if (problem == "Enough")
                //{
                //    Console.WriteLine($"Average score: {sum/count:f2}");
                //    Console.WriteLine($"Number of problems: {count}");
                //    Console.WriteLine($"Last problem: {last}");  //TO DO
                //    break;
                //}
                if (grade <= 4.00)
                {
                    countPoor++;
                }
                if (countPoor == poorGradesLimit)
                {
                    Console.WriteLine($"You need a break, {countPoor} poor grades.");
                    break;
                }

            }

        }
    }
}
