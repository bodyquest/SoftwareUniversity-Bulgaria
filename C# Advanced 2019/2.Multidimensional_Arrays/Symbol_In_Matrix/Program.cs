namespace Symbol_In_Matrix
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[,] jArr = new char[size,size];

            for (int i = 0; i < size; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                
                for (int j = 0; j < size; j++)
                {
                    jArr[i,j] = input[j];
                }
                
            }

            char symbol = char.Parse(Console.ReadLine());
            bool match = false;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (jArr[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        match = true;
                        return;
                    }
                }
            }

            if (!match)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
