namespace EXRC_Even_Lines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int count = 0;
            string specialSymbols = ",.-?!";

            using (var reader = new StreamReader("../../../text.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (count % 2 == 0)
                        {
                            if (count!= 0)
                            {
                                writer.WriteLine();
                            }
                            string changedLine = string.Empty;
                            foreach (var item in line)
                            {
                                if (specialSymbols.Contains(item))
                                {
                                    changedLine += '@';
                                }
                                else
                                {
                                    changedLine += item;
                                }
                            }

                            string[] splitLine = changedLine.Split();
                            Array.Reverse(splitLine);

                            writer.Write(string.Join(" ", splitLine));
                        }

                        line = reader.ReadLine();
                        count++;
                    }
                }
            }
        }
    }
}
