using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class test
    {
        static void Main(string[] args)
        {
            string initialFolder = @"C:\temp";
            var rootLevelFolders = Directory.GetDirectories(initialFolder);  //get all folders from the directory

            for (int currDirIndex = 0; currDirIndex < rootLevelFolders.Length; currDirIndex++)
            {
                Console.WriteLine($"---- {rootLevelFolders[currDirIndex]} ----");

                var subFolders = Directory.GetDirectories(rootLevelFolders[currDirIndex]);  // get all subfolders from each folder in the directory
                for (int subDir = 0; subDir < subFolders.Length; subDir++)
                {
                    var fileNames = Directory.GetFiles(subFolders[currDirIndex]);

                    for (int fileNameIndex = 0; fileNameIndex < fileNames.Length; fileNameIndex++)
                    {
                        File.
                        Console.WriteLine(fileNames[fileNameIndex]);
                    }
                    Console.WriteLine(subFolders[currDirIndex]);
                }


            }

            
        }
    }
}
