using System;
using System.Linq;


public class Program
{
   
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Console.WriteLine(MergeSort(arr));
    }

    public static int MergeSort(int[] arr)
    {
        int[] temp = new int[arr.Length];
        return RecursiveMergeSort(arr, temp, 0, arr.Length - 1);
    }


    public static int RecursiveMergeSort(int[] arr, int[] temp, int left, int right)
    {
        int invCount = 0;
        if (right <= left)
        {
            return invCount;
        }

        int mid = (right + left) / 2;

        invCount = RecursiveMergeSort(arr, temp, left, mid);
        invCount += RecursiveMergeSort(arr, temp, mid + 1, right);

        invCount += Merge(arr, temp, left, mid + 1, right);

        return invCount;
    }


    public static int Merge(int[] arr, int[] temp, int left, int mid, int right)
    {
        int i = left;
        int j = mid;
        int k = left;

        int invCount = 0;

        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];

                invCount = invCount + (mid - i);
            }
        }

        while (i <= mid - 1)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];


        for (i = left; i <= right; i++)
            arr[i] = temp[i];

        return invCount;
    }

}
