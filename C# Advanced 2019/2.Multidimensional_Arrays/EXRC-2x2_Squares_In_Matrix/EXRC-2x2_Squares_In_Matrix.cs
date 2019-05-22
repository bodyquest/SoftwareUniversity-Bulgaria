namespace EXRC_2x2_Squares_In_Matrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var size = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];
            var multi = new char[rows, cols];

            int squareCount = 0;
            FillMatrix(multi);

            Console.WriteLine(CountSquaredMatrices(multi, squareCount));
        }

        private static int CountSquaredMatrices(char[,] multi, int squareCount)
        {
            for (int row = 0; row < multi.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < multi.GetLength(1) - 1; col++)
                {
                    if (multi[row, col] == multi[row, col + 1]
                        && multi[row, col] == multi[row + 1, col]
                        && multi[row, col] == multi[row + 1, col + 1])
                    {
                        squareCount++;
                    }
                }
            }

            return squareCount;
        }

        private static void FillMatrix(char[,] multi)
        {
            for (int row = 0; row < multi.GetLength(0); row++)
            {
                char[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
                for (int col = 0; col < multi.GetLength(1); col++)
                {
                    multi[row, col] = array[col];
                }
            }
        }
    }
}
