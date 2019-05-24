namespace EXRC_Bomb_The_Basement
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
            int rows = size[0];
            int cols = size[1];

            var basement = new int[rows][];

            for (int row = 0; row < basement.Length; row++)
            {
                basement[row] = new int[cols];
            }

            var bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int bombRow = bomb[0];
            int bombCol = bomb[1];
            int bombRadius = bomb[2];

            for (int row = 0; row < basement.Length; row++)
            {
                for (int col = 0; col < basement[row].Length; col++)
                {
                    bool isInRadius = Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2) <= Math.Pow(bombRadius, 2);
                    if (isInRadius)
                    {
                        basement[row][col] = 1;
                    }
                }
            }

            int rowNum = 0;
            for (int col = 0; col < cols; col++)
            {
                int count = 0;
                for (int row = 0; row < basement[rowNum].Length; row++)
                {
                    if (basement[row][col] == 1)
                    {
                        count++;
                        basement[row][col] = 0;
                    }
                }

                for (int row = 0; row < count; row++)
                {
                    basement[row][col] = 0;
                }

                rowNum++;
            }

            foreach (var row in basement)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
