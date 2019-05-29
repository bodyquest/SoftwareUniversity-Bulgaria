namespace Line_Numbers
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../../../Resources/02.Line Numbers/Input.txt"))
            {
                using (var writer = new StreamWriter("../../../../Resources/02.Line Numbers/Output.txt"))
                {
                    int count = 1;

                    while (true)
                    {
                        var line = reader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        line = $"{count}. {line}";
                        count++;
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
