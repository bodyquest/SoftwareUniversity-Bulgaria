using System;
using System.Linq;


public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int toFind = int.Parse(Console.ReadLine());

        BinarySearch(arr,toFind, 0, arr.Length - 1);
    }

    private static void BinarySearch(int[] array, int toFind, int leftBorder, int rightBorder)
    {
        if (rightBorder < leftBorder)
        {
            Console.WriteLine(-1);
            return;
        }

        int middleIndex = (leftBorder + rightBorder)/2;

        if (array[middleIndex] == toFind)
        {
            Console.WriteLine(middleIndex);
            return;
        }

        if (array[middleIndex] > toFind)
        {
            BinarySearch(array, toFind, leftBorder, middleIndex - 1);
        }
        else
        {
            BinarySearch(array, toFind, middleIndex + 1, rightBorder);
        }
    }
}
