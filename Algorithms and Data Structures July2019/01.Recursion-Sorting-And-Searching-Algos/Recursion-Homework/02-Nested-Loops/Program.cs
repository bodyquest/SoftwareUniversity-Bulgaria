using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        PrintLoops(arr, 0);
    }

    private static void PrintLoops(int[] arr, int index)
    {
        if (index == arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = 1; i <= arr.Length; i++)
        {
            arr[index] = i;
            PrintLoops(arr, index + 1);
        }
    }
}
