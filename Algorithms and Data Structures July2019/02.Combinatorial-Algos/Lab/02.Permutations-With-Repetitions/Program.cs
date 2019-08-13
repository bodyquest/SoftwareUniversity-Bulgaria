using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static string[] letters;
    public static void Main()
    {
        letters = Console.ReadLine().Split().ToArray();

        GenPerm(0);
    }

    private static void GenPerm(int index)
    {
        if (index == letters.Length)
        {
            Console.WriteLine(string.Join(" ", letters));
            return;
        }
     
        HashSet<string> used = new HashSet<string>();
        for (int i = index; i < letters.Length; i++)
        {
            if (!used.Contains(letters[i]))
            {
                
                Swap(index, i);
                GenPerm(index + 1);
                Swap(index, i);
                used.Add(letters[i]);
            }
        }
    }

    private static void Swap(int index, int index2)
    {
        string temp = letters[index];
        letters[index] = letters[index2];
        letters[index2] = temp;
    }
}
