namespace EXRC_Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var files = Directory.GetFiles(".", "*.*");
            Dictionary < string, List<FileInfo>> extensionFileInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                if (!extensionFileInfo.ContainsKey(info.Extension))
                {
                    extensionFileInfo[info.Extension] = new List<FileInfo>();
                    extensionFileInfo[info.Extension].Add(info);
                }
            }

            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Report.txt";

            using (StreamWriter writer = new StreamWriter(pathToDesktop))
            {
                foreach (var kvp in extensionFileInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    string ext = kvp.Key;
                    var info = kvp.Value;
                    writer.WriteLine(ext);

                    foreach (var fileInfo in info.OrderByDescending(x => x.Length))
                    {
                        string name = fileInfo.Name;
                        double size = fileInfo.Length / 1024;

                        writer.WriteLine($"--{name} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
