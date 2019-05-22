namespace EXRC_Diagonal_Difference
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var multi = new int[matrixSize, matrixSize];

            for (int row = 0; row < multi.GetLength(0); row++)
            {
                var array = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < multi.GetLength(1); col++)
                {
                    multi[row, col] = array[col];
                }
            }

            int primaryDiagonal = 0;
            int cols = 0;
            for (int row = 0; row < multi.GetLength(0); row++)
            {
                primaryDiagonal += multi[row, cols];
                cols++;
            }

            int secondaryDiagonal = 0;
            cols = multi.GetLength(1) - 1;
            for (int row = 0; row < multi.GetLength(0); row++)
            {
                secondaryDiagonal += multi[row, cols];
                cols--;
            }

            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}
