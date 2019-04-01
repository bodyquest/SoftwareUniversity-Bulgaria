using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotOnLine
{
    class DotOnLine
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            if (
                ((first > second) &&
               ((first >= point) && (second <= point))
               )
               || ((first < second) &&
               ((first <= point) && (second >= point))
               )
               )
            {
                Console.WriteLine("in");
                if (Math.Abs(first - point) < Math.Abs(second - point))
                {
                    Console.WriteLine(Math.Abs(first - point));
                }
                else
                {
                    Console.WriteLine(Math.Abs(second - point));
                }
            }
            else
            {
                Console.WriteLine("out");
                if (Math.Abs(first - point) < Math.Abs(second - point))
                {
                    Console.WriteLine(Math.Abs(first - point));
                }
                else
                {
                    Console.WriteLine(Math.Abs(second - point));
                }
            }
        }
    }
}
