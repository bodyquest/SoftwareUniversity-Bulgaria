using System;


public class Program
{
    public static void Main()
    {
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        int[,] lcs = new int[str1.Length + 1, str2.Length + 1];

        for (int row = 1; row <= str1.Length; row++)
        {
            for (int col = 1; col <= str2.Length; col++)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    lcs[row, col] += lcs[row - 1, col - 1] + 1;
                }
                else
                {
                    lcs[row, col] = Math.Max(lcs[row - 1, col], lcs[row, col - 1]);
                }
            }
        }

        Console.WriteLine(lcs[str1.Length, str2.Length]);
    }
}
