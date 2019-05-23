namespace EXRC_Snake_Moves
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var input = Console.ReadLine();
            var snake = input.ToCharArray();
            Queue<char> snakeQ = new Queue<char>(snake);
            int rows = size[0];
            int cols = size[1];

            var multi = new char[rows, cols];
            for (int row = 0; row < multi.GetLength(0); row++)
            {
                for (int col = 0; col < multi.GetLength(1); col++)
                {
                    char item = snakeQ.Dequeue();
                    multi[row, col] = item;
                    snakeQ.Enqueue(item);
                }
            }

            for (int row = 0; row < multi.GetLength(0); row++)
            {
                for (int col = 0; col < multi.GetLength(1); col++)
                {
                    Console.Write("{0}{1}", multi[row, col], col == multi.GetLength(1) -1 ? "\n" : "");
                }
            }
        }
    }
}
