using System;
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

        GenPerm(index + 1);
        bool[] used = new bool[letters.Length];
        for (int i = index + 1; i < letters.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                Swap(index, i);
                GenPerm(index + 1);
                Swap(index, i);
                used[i] = false;
            }

            
        }
    }

    private static void Swap(int index1, int index2)
    {
        string temp = letters[index1];
        letters[index1] = letters[index2];
        letters[index2] = temp;
    }
}
