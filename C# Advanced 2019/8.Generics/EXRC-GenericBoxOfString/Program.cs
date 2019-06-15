namespace EXRC_GenericBoxOfString
{
    using System;

    class Program
    {
        static void Main()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string content = Console.ReadLine();
                Box<string> boxWithString= new Box<string>(content);
                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}
