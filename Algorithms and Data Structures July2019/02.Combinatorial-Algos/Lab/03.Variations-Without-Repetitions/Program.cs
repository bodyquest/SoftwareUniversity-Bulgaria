using System;
using System.Linq;


public class Program
{
    private static string[] letters;
    private static string[] set;
    public static void Main()
    {
        letters = Console.ReadLine().Split().ToArray();
        int n = int.Parse(Console.ReadLine());
        set = new string[n];

        bool[] used = new bool[letters.Length];

        GenVars(0, used);
    }

    private static void GenVars(int index, bool[] used)
    {
        if (index == set.Length)
        {
            Console.WriteLine(string.Join(" ", set));
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                set[index] = letters[i];
                GenVars(index + 1, used);
                used[i] = false;
            }
        }
    }
}
