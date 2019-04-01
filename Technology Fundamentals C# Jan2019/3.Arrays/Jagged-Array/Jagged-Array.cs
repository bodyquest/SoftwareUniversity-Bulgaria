using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            // three people having different AMOUNT qualifications
            string[] employeeNames = new string[3];
            employeeNames[0] = "Mark";
            employeeNames[1] = "Matt";
            employeeNames[2] = "John";

            string[][] jagged = new string[3][];

            jagged[0] = new string[3];
            jagged[1] = new string[1];
            jagged[2] = new string[2];

            jagged[0][0] = "bachelors";
            jagged[0][1] = "masters";
            jagged[0][2] = "doctorate";

            jagged[1][0] = "bachelors";

            jagged[2][0] = "bachelors";
            jagged[2][1] = "masters";

            for (int i = 0; i < jagged.Length; i++)
            {
                string[] inner = jagged[i];
                Console.WriteLine(employeeNames[i]);
                for (int j = 0; j < inner.Length; j++)
                {
                    Console.WriteLine(inner[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
