
namespace Sum_Matrix_Columns
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int columns = matrixSize[1];

            int sum = 0;
            var multi = new int[rows, columns];
            var columnSum = new List<int>();

            for (int i = 0; i < rows; i++)
            {
                var array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    multi[i, col] = array[col];
                }
            }


            for (int col = 0; col < columns; col++)
            {
                for (int i = 0; i < rows; i++)
                {
                    sum += multi[i, col];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }
    }
}
