namespace EXRC_Zip_And_Extract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class Program
    {
        public static void Main()
        {
            string filePath = "../../../copyMe.png";
            string zipPath = "../../../result.zip";
            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/UnzipDir/";

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath));
            }

            ZipFile.ExtractToDirectory(zipPath, pathToDesktop);
        }
    }
}
