using System;
using System.CodeDom.Compiler;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] set = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int n = int.Parse(Console.ReadLine());

        int[] vector = new int[n];

        GenerateCombinations(set,vector, 0, 0);
    }

    private static void GenerateCombinations(int[] set, int[] vector, int index, int border)
    {
        if (index == vector.Length)
        {
            Console.WriteLine(string.Join(" ", vector));
            return;
        }

        for (int i = border; i < set.Length; i++)
        {
            vector[index] = set[i];
            GenerateCombinations(set,vector, index + 1, i + 1);
        }
    }
}
