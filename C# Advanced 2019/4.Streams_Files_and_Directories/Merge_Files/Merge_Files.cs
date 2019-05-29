namespace Merge_Files
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            var readerOne = new StreamReader("../../../../Resources/04.Merge Files/FileOne.txt");
            var readerTwo = new StreamReader("../../../../Resources/04.Merge Files/FileTwo.txt");

            using (var writer = new StreamWriter("../../../../Resources/04.Merge Files/output.txt"))
            {
                while (true)
                {
                    var lineOne = readerOne.ReadLine();
                    var lineTwo = readerTwo.ReadLine();
                    if (lineOne == null)
                    {
                        if (lineTwo != null)
                        {
                            lineTwo = readerTwo.ReadLine();
                            writer.WriteLine(lineTwo);
                        }
                        break;
                    }
                    else if (lineTwo == null)
                    {
                        if (lineOne != null)
                        {
                            lineOne = readerOne.ReadLine();
                            writer.WriteLine(lineOne);
                        }
                        break;
                    }
                    else
                    {
                        writer.WriteLine(lineOne);
                        writer.WriteLine(lineTwo);
                    }
                }
            }

            readerOne.Close();
            readerTwo.Close();
        }
    }
}

