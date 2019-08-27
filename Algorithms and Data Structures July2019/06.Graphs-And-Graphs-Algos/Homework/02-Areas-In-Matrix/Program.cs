using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

class Program
{
    private static char[,] matrix;
    private static bool[,] visited;
    private static Dictionary<char, int> counts;
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] firstLine = Console.ReadLine().ToCharArray();

        matrix = new char[n,firstLine.Length];
        visited = new bool[n,firstLine.Length];
        counts = new Dictionary<char, int>();

        for (int col = 0; col < firstLine.Length; col++)
        {
            matrix[0, col] = firstLine[col];
        }

        for (int row = 1; row < n; row++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int col = 0; col < line.Length; col++)
            {
                matrix[row, col] = line[col];
            }
        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < firstLine.Length; col++)
            {
                char currentChar = matrix[row, col];
                if (!visited[row, col])
                {
                    if (!counts.ContainsKey(currentChar))
                    {
                        counts[currentChar] = 0;
                    }

                    TraverseArea(row, col, currentChar);
                    counts[currentChar]++;
                }
            }
        }

        Console.WriteLine("Areas: " + counts.Values.Sum());
        foreach (var kvp in counts.OrderBy(x => x.Key))
        {
            Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
        }
    }

    private static void TraverseArea(int row, int col, char c)
    {
        if (!IsValidCell(row, col))
        {
            return;
        }

        if (matrix[row, col] != c)
        {
            return;
        }

        if (visited[row, col])
        {
            return;
        }

        visited[row, col] = true;
        TraverseArea(row - 1, col, c);
        TraverseArea(row + 1, col, c);
        TraverseArea(row, col - 1, c);
        TraverseArea(row, col + 1, c);
        

    }

    public static bool IsValidCell(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        return true;
    }
}
