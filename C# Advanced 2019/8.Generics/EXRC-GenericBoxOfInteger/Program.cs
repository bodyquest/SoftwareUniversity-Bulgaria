namespace EXRC_GenericBoxOfInteger
{
    using System;

    public class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                int content = int.Parse(Console.ReadLine());
                BoxOfInt<int> boxWithInt = new BoxOfInt<int>(content);
                Console.WriteLine(boxWithInt.ToString());
            }
        }
    }
}
