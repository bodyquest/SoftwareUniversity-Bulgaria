using System;


public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Draw(n);
    }

    private static void Draw(int number)
    {
        if (number == 0)
        {
            return;
        }

        Console.WriteLine(new string('*', number));
        Draw(number - 1);
        Console.WriteLine(new string('#', number));
    }
}
