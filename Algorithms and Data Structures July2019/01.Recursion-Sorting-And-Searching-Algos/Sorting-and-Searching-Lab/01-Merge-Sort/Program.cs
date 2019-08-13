using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

        array = MergeSort<int>.Sort(array);

        Console.WriteLine(string.Join(" ", array));
    }
}
