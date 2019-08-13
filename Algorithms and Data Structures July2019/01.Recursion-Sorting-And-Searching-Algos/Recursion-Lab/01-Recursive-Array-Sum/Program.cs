using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(RecursiveSum(array, 0));
    }

    private static int RecursiveSum(int[] array, int index)
    {
        if (index == array.Length)
        {
            return 0;
        }

        return array[index] + RecursiveSum(array, index + 1);
    }
}
