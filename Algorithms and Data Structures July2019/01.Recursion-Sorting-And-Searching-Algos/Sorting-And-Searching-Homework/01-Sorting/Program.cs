using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public abstract class SortingStrategy
{
    public abstract void Sort(List<int> arr);

    public static void Swap(List<int> arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
}

public class InsertionSortingStrategy : SortingStrategy
{
    public override void Sort(List<int> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (arr[j - 1] > arr[j])
                {
                    Swap(arr, j - 1, j);
                }
            }
        }
    }
}

public class BubbleSortingStrategy : SortingStrategy
{
    public override void Sort(List<int> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            for (int j = i + 1; j < arr.Count; j++)
            {
                if (arr[i] > arr[j])
                {
                    Swap(arr, i, j);
                }
            }
        }
    }
}

public class MergeSortingStrategy : SortingStrategy
{
    public override void Sort(List<int> arr)
    {
        List<int> temp = new List<int>(arr.Count);

        RecursiveMergeSort(arr, temp, 0, arr.Count - 1);
    }

    private void RecursiveMergeSort(List<int> arr, List<int> temp, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int mid = (left + right) / 2;

        RecursiveMergeSort(arr, temp, left, mid);
        RecursiveMergeSort(arr, temp, mid + 1, right);

        Merge(arr, temp, left, mid + 1, right);
    }

    private void Merge(List<int> arr, List<int> temp, int left, int mid, int right)
    {
        int i = left;
        int j = mid;
        int k = left;

        while ((i <= mid - 1) && (j <= right))
        {
            if (arr[i] <= arr[j])
            {
                temp[k] = arr[i];
            }
            else
            {
                temp[k] = arr[j];
            }

            k++;
            i++;
            j++;
        }

        while (i <= mid - 1)
        {
            temp[k] = arr[i];
            k++;
            i++;
        }

        while (j <= right)
        {
            temp[k] = arr[j];
            k++;
            j++;
        }

        for (i = left; i <= right; i++)
        {
            arr[i] = temp[i];
        }
    }
}


public class Program
{
    public static void Main()
    {
        List<int> arr = Console.ReadLine().Split().Select(int.Parse).ToList();

        Sort(arr, new MergeSortingStrategy());

        Console.WriteLine(string.Join(" ", arr));
    }

    private static void Sort(List<int> arr, SortingStrategy strategy)
    {
        strategy.Sort(arr);
    }
}
