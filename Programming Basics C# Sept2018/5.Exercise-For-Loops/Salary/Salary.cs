using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Salary
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            string penalty = String.Empty;

            for (int i = 0; i < tabs; i++)
            {
                penalty = Console.ReadLine();
                if (penalty == "Facebook")
                {
                    salary -= 150;
                }
                if (penalty == "Instagram")
                {
                    salary -= 100;
                }
                if (penalty == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    break;
                }
            }
            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }

        }
    }
}
