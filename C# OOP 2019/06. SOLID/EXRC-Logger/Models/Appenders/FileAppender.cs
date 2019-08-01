namespace EXRC_Logger.Models.Appenders
{
    using System;
    using System.Globalization;

    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;

    public class FileAppender : IAppender
    {
        private int messagesAppended;
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        private FileAppender()
        {
            this.messagesAppended = 0;
        }

        public FileAppender(ILayout layout, Level level, IFile file)
            : this()
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public void Append(IError error)
        {
            string formatted = this.File
               .Write(this.Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formatted);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended} File Size: {this.File.Size}";
        }
    }
}
