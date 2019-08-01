namespace EXRC_Logger.Models.Files
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Globalization;

    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;
    using EXRC_Logger.Models.IOManagement;

    public class LogFile : IFile
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        private const string currentDirectory = "\\logs\\";
        private const string currentFile = "log.txt"; 

        private string currentPath;
        private IIOManager IOManager;

        public LogFile()
        {
            this.IOManager = new IOManager(currentDirectory, currentFile);
            this.currentPath = this.IOManager.GetCurrentPath();
            this.IOManager.EnsureDirectoryAndFileExist();
            this.Path = currentPath + currentDirectory + currentFile;
        }

        public string Path { get; private set; }

        public ulong Size => GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatted = String.Format(format,dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);

            return formatted;
        }

        private ulong GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            ulong size = (ulong)text
                .ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => (int)c);

            return size;
        }
    }
}
