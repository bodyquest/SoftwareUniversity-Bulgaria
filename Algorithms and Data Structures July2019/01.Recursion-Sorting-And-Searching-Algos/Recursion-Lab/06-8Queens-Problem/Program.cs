using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public class Program
{
    public static int solutionsFound;

    public static bool[,] board = new bool[8, 8];

    public static HashSet<int> attackedRows = new HashSet<int>();
    public static HashSet<int> attackedCols = new HashSet<int>();
    public static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
    public static HashSet<int> attackedRightDiagonals = new HashSet<int>();

    public static void Main()
    {
        PutQueen(0);
    }

    private static void PutQueen(int row)
    {
        if (row == 8)
        {
            PrintSolution();
            return;
        }

        for (int col = 0; col < 8; col++)
        {
            if (CanPlaceQueen(row,col))
            {
                MarkAllAttackedPositions(row,col);
                PutQueen(row + 1);
                UnmarkAllAttackedPositions(row,col);
            }
        }
    }

    private static void PrintSolution()
    {
        solutionsFound++;

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (board[row,col])
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("- ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static bool CanPlaceQueen(int row, int col)
    {
        bool attackedPosition = attackedRows.Contains(row) || attackedCols.Contains(col) ||
                                attackedLeftDiagonals.Contains(col - row) || 
                                attackedRightDiagonals.Contains(row + col);

        return !attackedPosition;
    }

    private static void MarkAllAttackedPositions(int row, int col)
    {
        attackedCols.Add(col);
        attackedRows.Add(row);
        attackedLeftDiagonals.Add(col - row);
        attackedRightDiagonals.Add(row + col);
        board[row, col] = true;
    }


    private static void UnmarkAllAttackedPositions(int row, int col)
    {
        attackedCols.Remove(col);
        attackedRows.Remove(row);
        attackedLeftDiagonals.Remove(col - row);
        attackedRightDiagonals.Remove(row + col);
        board[row, col] = false;
    }
}
