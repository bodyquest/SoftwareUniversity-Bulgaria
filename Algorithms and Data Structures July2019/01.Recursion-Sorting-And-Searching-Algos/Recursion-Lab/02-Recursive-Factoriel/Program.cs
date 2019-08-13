using System;


public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(PrintFactorial(n));
    }

    private static long PrintFactorial(int number)
    {
        if (number == 1)
        {
            return 1;
        }

        return number * PrintFactorial(number - 1);
    }
}
