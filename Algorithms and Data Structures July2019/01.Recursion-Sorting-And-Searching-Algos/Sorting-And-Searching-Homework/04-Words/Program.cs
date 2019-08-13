using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int Count = 0;
    private static char[] letters;

    public static void Main(string[] args)
    {
        letters = Console.ReadLine().ToCharArray();

        var distinct = letters.Distinct().ToArray();
        if (distinct.Length == letters.Length)
        {
            Console.WriteLine(GetFact(distinct.Length));
            return;
        }

        GeneratePerm(0);

        Console.WriteLine(Count);
    }

    private static long GetFact(int distinctLength)
    {
        long res = 1;

        for (int i = 1; i <= distinctLength; i++)
        {
            res *= i;
        }

        return res;
    }

    private static void GeneratePerm(int index)
    {
        if (index == letters.Length)
        {
            if (IsValidPerm())
            {
                Count++;
            }

            return;
        }

        HashSet<char> swapped = new HashSet<char>();

        for (int i = index; i < letters.Length; i++)
        {
            if (!swapped.Contains(letters[i]))
            {
                Swap(index, i);
                GeneratePerm(index + 1);
                Swap(index, i);

                swapped.Add(letters[i]);
            }

            
        }
    }

    private static bool IsValidPerm()
    {
        for (int i = 0; i < letters.Length - 1; i++)
        {
            if (letters[i] == letters[i + 1])
            {
                return false;
            }
        }

        return true;
    }

    private static void Swap(int index, int index2)
    {
        char temp = letters[index];
        letters[index] = letters[index2];
        letters[index2] = temp;
    }
}
