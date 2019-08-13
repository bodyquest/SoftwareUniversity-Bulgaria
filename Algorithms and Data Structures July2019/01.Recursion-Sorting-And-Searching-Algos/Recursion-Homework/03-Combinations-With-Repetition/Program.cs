using System;

public class Program
{
    public static void Main()
    {
        int setLength = int.Parse(Console.ReadLine());
        int arrLength = int.Parse(Console.ReadLine());

        int[] set = new int[setLength];

        for (int i = 0; i < setLength; i++)
        {
            set[i] = i + 1;
        }

        int[] arr = new int[arrLength];

        GenerateCombinations(set, arr, 0, 0);
    }

    private static void GenerateCombinations(int[] set, int[] arr, int index, int border)
    {
        if (index == arr.Length)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = border; i < set.Length; i++)
        {
            arr[index] = set[i];
            GenerateCombinations(set,arr,index + 1, i);
        }
    }
}
