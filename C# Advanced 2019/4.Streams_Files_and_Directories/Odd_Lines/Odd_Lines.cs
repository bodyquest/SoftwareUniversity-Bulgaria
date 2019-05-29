namespace Odd_Lines
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../../Resources/01.Odd Lines/Input.txt"))
            {
                int count = 0;
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    count++;
                }
            }
        }
    }
}
