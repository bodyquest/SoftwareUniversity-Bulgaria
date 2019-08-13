using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static List<char> path = new List<char>();
    public static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        char[,] lab = new char[rows, cols];

        for (int row = 0; row < rows; row++)
        {
            char[] rowChars = Console.ReadLine().ToCharArray();

            for (int col = 0; col < cols; col++)
            {
                lab[row, col] = rowChars[col];
            }
        }

        FindAllPaths(lab, 0, 0, 'S');
    }

    private static void FindAllPaths(char[,] lab, int currentRow, int currentCol, char dir)
    {
        if (!IsValidCell(lab, currentRow, currentCol))
        {
            return;
        }

        path.Add(dir);

        if (lab[currentRow, currentCol] == 'e')
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }
        else
        {
            lab[currentRow, currentCol] = '$';

            FindAllPaths(lab, currentRow + 1, currentCol, 'D');
            FindAllPaths(lab, currentRow - 1, currentCol, 'U');
            FindAllPaths(lab, currentRow, currentCol - 1, 'L');
            FindAllPaths(lab, currentRow, currentCol + 1, 'R');

            lab[currentRow, currentCol] = '-';
        }

        path.RemoveAt(path.Count - 1);

    }

    private static bool IsValidCell(char[,] lab, int row, int col)
    {
        if ((row < 0 || row >= lab.GetLength(0)) || (col < 0 || col >= lab.GetLength(1)))
        {
            return false;
        }

        return lab[row, col] == '-' || lab[row, col] == 'e';
    }
}
