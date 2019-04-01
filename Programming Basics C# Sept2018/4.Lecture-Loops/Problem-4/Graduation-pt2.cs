using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double counter = 1;
            double counter2 = 1;
            double sum = 0;
            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    sum += grade;
                    counter++;
                }
                if (grade <4)
                {
                    
                    if (counter2 > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {counter} grade");
                        return;
                    }
                    counter2++;
                }
            }
            double average = sum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {average:f2}");
        }
    }
}
