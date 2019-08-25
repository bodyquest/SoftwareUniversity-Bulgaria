using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] side1 = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();


        int[] side2 = side1
            .OrderBy(c => c)
            .ToArray();

        int length = side1.Length;
        int[,] connectingCounts = new int[length + 1, length + 1];

        for (int i = 1; i <= length; i++)
        {
            for (int j = 1; j <= length; j++)
            {
                if (side1[i - 1] == side2[j - 1])
                {
                    connectingCounts[i, j] = connectingCounts[i - 1, j - 1] + 1;
                }
                else
                {
                    connectingCounts[i, j] = Math.Max(connectingCounts[i - 1, j], connectingCounts[i, j - 1]);
                }
            }
        }

        Console.WriteLine($"Maximum pairs connected: {connectingCounts[length, length]}");
    }
}
