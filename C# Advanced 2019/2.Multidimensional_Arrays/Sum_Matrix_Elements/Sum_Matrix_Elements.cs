namespace Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var arraySize = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = arraySize[0];
            int columns = arraySize[1];

            int sum = 0;

            var multi = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                var array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    multi[i, col] = array[col];
                    sum += array[col];
                }
            }

            Console.WriteLine(multi.GetLength(0));
            Console.WriteLine(multi.GetLength(1));
            Console.WriteLine(sum);



        }
    }
}
