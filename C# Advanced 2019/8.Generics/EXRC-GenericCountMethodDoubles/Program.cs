namespace EXRC_GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            Box<double> boxWithString = new Box<double>();

            for (int i = 0; i < lines; i++)
            {
                double line = double.Parse(Console.ReadLine());
                boxWithString.AddToList(line);
            }

            double num = double.Parse(Console.ReadLine());
            int count = GetCountOfGreaterElements(boxWithString.Data, num);
            Console.WriteLine(count);
        }

        public static int GetCountOfGreaterElements<T>(List<T> listWithData, T element)
            where T : IComparable
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
