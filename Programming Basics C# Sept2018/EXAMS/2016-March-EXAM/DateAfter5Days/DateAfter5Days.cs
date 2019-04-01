using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAfter5Days
{
    class DateAfter5Days
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int newD = d + 5;

            if (m == 1 || m == 01 || m == 3 || m == 03 || m == 5 || m == 05 || m == 7 || m == 07 || m == 8 || m == 08)
            {
                if (newD > 31)
                {
                    newD = newD - 31;
                    m = m + 1;
                }
                Console.WriteLine(newD + "." + "0" + m);
            }
            else if (m == 4 || m == 04 || m == 6 || m == 06)
            {
                if (newD > 30)
                {
                    newD = newD - 30;
                    m = m + 1;
                }
                Console.WriteLine(newD + "." + "0" + m);
            }
            else if (m == 9 || m == 09)
            {
                if (newD > 30)
                {
                    newD = newD - 30;
                    m = m + 1;
                    Console.WriteLine(newD + "." + m);
                }
                else if (newD <= 30)
                {
                    Console.WriteLine(newD + "." + "0" + m);
                }
            }
            else if (m == 11)
            {
                if (newD > 30)
                {
                    newD = newD - 30;
                    m = m + 1;
                }
                Console.WriteLine(newD + "." + m);
            }
            else if (m == 2 || m == 02)
            {
                if (newD > 28)
                {
                    newD = newD - 28;
                    m = m + 1;
                }
                Console.WriteLine(newD + "." + "0" + m);
            }
            else if (m == 10)
            {
                if (newD > 31)
                {
                    newD = newD - 31;
                    m = m + 1;
                }
                Console.WriteLine(newD + "." + m);
            }
            else if (m == 12)
            {
                if (newD > 31)
                {
                    newD = newD - 31;
                    m = 1;
                    Console.WriteLine(newD + "." + "0" + m);
                }
                else if (newD <= 31)
                {
                    Console.WriteLine(newD + "." + m);
                }
            }
        }
    }
}
