using System;
using System.Numerics;

public class Program
{
    public static void Main()
    {
        int elementsCount = int.Parse(Console.ReadLine());
        int setCount = int.Parse(Console.ReadLine());
        int num = elementsCount - setCount;

        BigInteger elementsFact = GetFact(elementsCount);
        BigInteger setFact = GetFact(setCount);
        BigInteger numFact = GetFact(num);

        Console.WriteLine(elementsFact / (setFact * numFact));
    }

    private static BigInteger GetFact(int elementsCount)
    {
        BigInteger res = 1;

        for (int i = 1; i <= elementsCount; i++)
        {
            res *= i;
        }

        return res;
    }
}
