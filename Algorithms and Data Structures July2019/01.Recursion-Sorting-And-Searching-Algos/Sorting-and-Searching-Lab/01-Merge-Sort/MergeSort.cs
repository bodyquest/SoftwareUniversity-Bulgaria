using System;
using System.Collections.Generic;
using System.Text;


public static class MergeSort<T>
{
    public static T[] Sort(T[] array)
    {

        return array;
    }

    private static void Swap(T[] arr, int index1, int index2)
    {
        T temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
}

