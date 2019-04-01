using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            int n = int.Parse(Console.ReadLine());
            int [] prev = new int[1];
            for (int row = 0; row < n; row++)                     // 0 1 2 3 row index
            {
                int[] arrRow = new int[row + 1];                  //   2 3 4 elements in arrRow
                if (row == 0)
                {
                    prev[0] = 1;
                    Console.WriteLine(prev[0]);
                    continue;
                }
                for (int arrIndex = 0; arrIndex < row+1; arrIndex++)
                {
                    if (arrIndex== 0)
                    {
                        arrRow[0] = prev[0];                            //peak of the triangle
                        Console.Write(arrRow[arrIndex]);
                        continue;
                    }
                    if (arrIndex <= prev.Length - 1 && arrIndex > 0)    //calc. if column !> than prevRow column
                    {
                        arrRow[arrIndex] = prev[arrIndex - 1] + prev[arrIndex];
                    }
                    else if(arrIndex > prev.Length - 1)
                    {
                        arrRow[arrIndex] = prev[arrIndex - 1];
                    }

                    Console.Write($" {arrRow[arrIndex]}");

                    if (arrIndex == arrRow.Length-1)
                    {
                        Console.WriteLine();
                    }
                }

                prev = arrRow;
            }
        }
    }
}
