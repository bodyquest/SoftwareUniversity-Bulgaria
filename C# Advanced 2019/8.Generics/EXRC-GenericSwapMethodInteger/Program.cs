namespace EXRC_GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Box<int> boxWithInt = new Box<int>();

            for (int i = 0; i < lines; i++)
            {
                int content = int.Parse(Console.ReadLine());
                boxWithInt.AddToList(content);
            }

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstIndx = indexes[0];
            int secondIndx = indexes[1];

            boxWithInt.Swap(firstIndx, secondIndx);
            Console.WriteLine(boxWithInt);
        }
    }
}
