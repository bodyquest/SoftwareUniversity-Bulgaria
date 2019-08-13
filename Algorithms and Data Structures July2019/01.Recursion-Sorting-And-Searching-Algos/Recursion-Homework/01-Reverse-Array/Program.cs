using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        arr = ReverseArray(arr,0, arr.Length - 1);

        Console.WriteLine(string.Join(" ", arr));
    }

    private static int[] ReverseArray(int[] arr, int index, int index2)
    {
        if (index2 <= index)
        {
            return arr;
        }

        int temp = arr[index];
        arr[index] = arr[index2];
        arr[index2] = temp;

        return ReverseArray(arr, index + 1, index2 - 1);
    }
}
