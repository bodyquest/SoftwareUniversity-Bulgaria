using System;
using System.Linq;

public class Program
{
    public static string[] letters;
    public static string[] set;
    
    public static void Main()
    {
        letters = Console.ReadLine().Split().ToArray();
        int n = int.Parse(Console.ReadLine());
        set = new string[n];

        GenVars(0);

    }

    private static void GenVars(int index)
    {
        if (index == set.Length)
        {
            Console.WriteLine(string.Join(" ", set));
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            set[index] = letters[i];
            GenVars(index + 1);
        }
    }
}
