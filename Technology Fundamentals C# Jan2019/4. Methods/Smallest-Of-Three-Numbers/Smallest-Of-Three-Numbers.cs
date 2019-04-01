using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int one = int.Parse(Console.ReadLine());
            int two = int.Parse(Console.ReadLine());
            int three = int.Parse(Console.ReadLine());

            Console.WriteLine(CompareNumbers(one, two, three));
        }

        static int CompareNumbers(int one, int two, int three)
        {
            if (one < two && one < three)
            {
                return one;
            }
            else if (two < one && two < three)
            {
                return two;
            }
            else
            {
                return three;
            }

        }
    }
}
