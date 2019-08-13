using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int areaSize;
    public static void Main()
    {
        List<Area> areas = new List<Area>();

        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            char[] rowInfo = Console.ReadLine().ToCharArray();

            for (int col = 0; col < cols; col++)
            {
                matrix[row, col] = rowInfo[col];
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col] == '-')
                {
                    Area area = GetArea(matrix, row, col);
                    areas.Add(area);
                }
            }
        }

        Console.WriteLine("Total areas found: " + areas.Count);
        int i = 1;
        foreach (var area in areas.OrderByDescending(x => x.Size).ThenBy(x => x.TopLeftRow).ThenBy(x => x.TopLeftCol))
        {
            Console.WriteLine($"Area #{i} at ({area.TopLeftRow}, {area.TopLeftCol}), size: {area.Size}");
            i++;
        }
    }

    private static Area GetArea(char[,] matrix, int row, int col)
    {
        int topLeftRow = row;
        int topLeftCol = col;

        MarkArea(matrix, row, col);

        Area area = new Area(topLeftRow, topLeftCol, areaSize);
        areaSize = 0;
        return area;
    }

    private static void MarkArea(char[,] matrix, int row, int col)
    {
        if (!CellIsValid(matrix, row, col))
        {
            return;
        }

        matrix[row, col] = '$';
        areaSize++;
        MarkArea(matrix, row + 1, col);
        MarkArea(matrix, row - 1, col);
        MarkArea(matrix, row, col + 1);
        MarkArea(matrix, row, col - 1);
    }

    private static bool CellIsValid(char[,] matrix, int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return matrix[row, col] == '-' || Char.IsDigit(matrix[row,col]);
    }
}
