using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicaitonTable
{
    class MultiplicaitonTable
    {
        static void Main(string[] args)
        {
            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 10; column++)
                {
                    Console.Write("{0} * {1} = {2}\t", column, row, column * row);
                }
                Console.WriteLine();
            }
        }
    }
}
