namespace EXRC_GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> boxWithString = new Box<string>();

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                boxWithString.AddToList(line);
            }

            string stringLine = Console.ReadLine();
            int count = GetCountOfGreaterElements(boxWithString.Data, stringLine);
            Console.WriteLine(count);
        }

        public static int GetCountOfGreaterElements<T>(List<T> listWithData, T element)
            where T: IComparable
        {
            int count = 0;

            foreach (var item in listWithData)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
