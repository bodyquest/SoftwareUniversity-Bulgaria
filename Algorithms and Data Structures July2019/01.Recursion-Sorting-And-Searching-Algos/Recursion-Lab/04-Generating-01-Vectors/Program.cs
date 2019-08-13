using System;

public class Program
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[] vector = new int[size];

        GenerateVectors(vector, 0);
    }

    private static void GenerateVectors(int[] vector, int index)
    {
        if (index == vector.Length)
        {
            Console.WriteLine(string.Join("", vector));
            return;
        }

        for (int i = 0; i <= 1; i++)
        {
            vector[index] = i;
            GenerateVectors(vector, index + 1);
        }
    }
}
