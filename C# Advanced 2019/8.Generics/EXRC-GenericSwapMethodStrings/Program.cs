namespace EXRC_GenericSwapMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> boxWithString = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                string stringLine = Console.ReadLine();
                boxWithString.AddToList(stringLine);
            }

            var indexes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int firstIndx = indexes[0];
            int secondIndx = indexes[1];

            Swap(boxWithString.Data, firstIndx, secondIndx);
            Console.WriteLine(boxWithString);
        }

        static void Swap<T>(List<T> listWithData, int firstIndx, int secondIndx)
        {
            T temp = listWithData[firstIndx];
            listWithData[firstIndx] = listWithData[secondIndx];
            listWithData[secondIndx] = temp;
        }
    }
}
