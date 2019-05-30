namespace EXRC_Line_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                int count = 1;

                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        int letterCount = 0;
                        int symbolsCount = 0;

                        foreach (var @char in line)
                        {
                            if (char.IsLetter(@char))
                            {
                                letterCount++;
                            }
                            else if (char.IsPunctuation(@char))
                            {
                                symbolsCount++;
                            }
                        }

                        writer.WriteLine($"Line {count}: {line} ({letterCount})({symbolsCount})");
                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
