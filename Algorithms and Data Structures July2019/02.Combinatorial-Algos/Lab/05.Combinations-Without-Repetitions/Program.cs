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

        GenCombos(0, 0);
    }

    private static void GenCombos(int index, int border)
    {
        if (index == set.Length)
        {
            Console.WriteLine(string.Join(" ", set));
            return;
        }

        for (int i = border; i < letters.Length; i++)
        {
            set[index] = letters[i];
            GenCombos(index + 1, i + 1);
        }
    }
}
