using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            int dir = int.Parse(Console.ReadLine());;
            int heading = 90;
            heading += dir;
            if (heading > 180)
            {
                heading %= 180;
            }
            Console.WriteLine(heading);
        }
    }
}
