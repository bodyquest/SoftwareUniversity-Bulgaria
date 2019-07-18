namespace EXRC_Logger.Models.IOManagement
{
    using System;
    using System.IO;

    using EXRC_Logger.Models.Interfaces;

    public class IOManager : IIOManager
    {
        private string currentPath;
        private string currentDirectory;
        private string currentFile;

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }

        public IOManager(string currentDirectory, string currentFile)
            : this()
        {
            this.currentDirectory = currentDirectory;
            this.currentFile = currentFile;
        }

        public string CurrentDirectoryPath => this.currentPath + this.currentDirectory;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.currentFile;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory
                (this.CurrentDirectoryPath);
            }

            //creates a file with empty string
            File.WriteAllText(this.CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
