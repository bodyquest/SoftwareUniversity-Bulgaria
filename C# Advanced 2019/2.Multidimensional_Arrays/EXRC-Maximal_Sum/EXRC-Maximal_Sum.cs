namespace EXRC_Maximal_Sum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            var multi = new int[rows, cols];
            var matrix9 = new int[3, 3];
            var MaxMatrix9 = new int[3, 3];
            int[] maxStartIndex = new int[2]; 
            FillMatrix(multi);

            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int row = 0; row < multi.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < multi.GetLength(1) - 2; col++)
                {
                    currentSum = multi[row, col]
                        + multi[row, col + 1]
                        + multi[row, col + 2]
                        + multi[row + 1, col]
                        + multi[row + 1, col + 1]
                        + multi[row + 1, col + 2]
                        + multi[row + 2, col]
                        + multi[row + 2, col + 1]
                        + multi[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxStartIndex[0] = row;
                        maxStartIndex[1] = col;
                    }
                }

                currentSum = 0;
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxStartIndex[0]; i < maxStartIndex[0]+3; i++)
            {
                for (int j = maxStartIndex[1]; j < maxStartIndex[1]+3; j++)
                {
                    Console.Write("{0}{1}", multi[i, j], j == maxStartIndex[1] + 2? "\n": " ");
                }
            }
        }

        private static void FillMatrix(int[,] multi)
        {
            for (int row = 0; row < multi.GetLength(0); row++)
            {
                int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < multi.GetLength(1); col++)
                {
                    multi[row, col] = array[col];
                }
            }
        }
    }
}
