namespace Folder_Size
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] files = Directory.GetFiles("../../../../Resources/06.Folder Size/TestFolder");
            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("../../../../Resources/06.Folder Size/output.txt", sum.ToString());

        }
    }
}
