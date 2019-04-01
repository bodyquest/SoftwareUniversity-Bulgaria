using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (i <= 122)
            {
                Console.Write((char)i + "\t");
                if (i % 10 == 0)
                    Console.Write("\n");

                i++;
            }

            Console.ReadLine();

        }
    }
}
