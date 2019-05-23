namespace EXRC_Matrix_Shuffling
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
            int[] maxStartIndex = new int[2];
            FillMatrix(multi);

            string input = Console.ReadLine();
            while (input != "END")
            {
                var array = input.Split(' ').ToArray();
                
                if (array[0] != "swap"
                    || array.Length != 5
                    || int.Parse(array[1]) < 0
                    || int.Parse(array[2]) < 0
                    || int.Parse(array[3]) < 0
                    || int.Parse(array[4]) < 0
                    || int.Parse(array[1]) > multi.GetLength(0) - 1
                    || int.Parse(array[2]) > multi.GetLength(1) - 1
                    || int.Parse(array[3]) > multi.GetLength(0) - 1
                    || int.Parse(array[4]) > multi.GetLength(1) - 1)
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (array[0] == "swap")
                {
                    int row1 = int.Parse(array[1]);
                    int col1 = int.Parse(array[2]);
                    int row2 = int.Parse(array[3]);
                    int col2 = int.Parse(array[4]);

                    var temp = multi[row1, col1];
                    multi[row1, col1] = multi[row2, col2];
                    multi[row2, col2] = temp;
                    PrintMatrix(multi);
                }

                input = Console.ReadLine();
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

        private static void PrintMatrix(int[,] multi)
        {
            for (int i = 0; i < multi.GetLength(0); i++)
            {
                for (int j = 0; j < multi.GetLength(1); j++)
                {
                    Console.Write("{0}{1}", multi[i, j], j == multi.GetLength(1) - 1 ? "\n" : " ");
                }
            }
        }
    }
}
