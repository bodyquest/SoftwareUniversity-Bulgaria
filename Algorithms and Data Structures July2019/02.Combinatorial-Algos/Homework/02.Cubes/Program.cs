using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int totalCubes = 1;
    private static string[] cubes;
    private static readonly HashSet<string> rotations = new HashSet<string>();

    public static void Main()
    {
        cubes = Console.ReadLine().Split().OrderBy(x => x).ToArray();

        Rotate();
        Permutate(0, cubes.Length - 1);

        Console.WriteLine(totalCubes);
    }

    private static void Rotate()
    {
        for (int z = 0; z < 4; z++)
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    var cube = string.Join("", cubes);
                    rotations.Add(cube);

                    RotateX();
                }

                RotateY();
            }

            RotateZ();
        }
    }

    private static void RotateX()
    {
        Swap(10, 0);
        Swap(11, 10);
        Swap(3, 11);

        Swap(9, 4);
        Swap(7, 9);
        Swap(1, 7);

        Swap(5, 2);
        Swap(6, 5);
        Swap(8, 6);
    }

    private static void RotateY()
    {
        Swap(3, 1);
        Swap(7, 3);
        Swap(8, 7);

        Swap(11, 0);
        Swap(6, 11);
        Swap(2, 6);

        Swap(10, 4);
        Swap(9, 10);
        Swap(5, 9);
    }

    private static void RotateZ()
    {
        Swap(6, 9);
        Swap(7, 6);
        Swap(11, 7);

        Swap(5, 10);
        Swap(8, 5);
        Swap(3, 8);

        Swap(2, 4);
        Swap(1, 2);
        Swap(0, 1);
    }

    public static void Permutate(int start, int end)
    {
        if (!rotations.Contains(string.Join("", cubes)))
        {
            totalCubes++;
            Rotate();
        }

        for (int left = end - 1; left >= start; left--)
        {
            for (int right = left + 1; right <= end; right++)
            {
                if (cubes[left] != cubes[right])
                {
                    Swap(left, right);
                    Permutate(left + 1, end);
                }
            }

            var firstElement = cubes[left];
            for (int i = left; i <= end - 1; i++)
            {
                cubes[i] = cubes[i + 1];
            }

            cubes[end] = firstElement;
        }
    }

    private static void Swap(int first, int second)
    {
        var temp = cubes[first];
        cubes[first] = cubes[second];
        cubes[second] = temp;
    }
}
