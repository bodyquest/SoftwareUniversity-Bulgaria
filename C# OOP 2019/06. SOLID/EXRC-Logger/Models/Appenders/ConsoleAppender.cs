namespace EXRC_Logger.Models.Appenders
{
    using System;
    using System.Globalization;

    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;

    public class ConsoleAppender : IAppender
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";
        private int messagesAppended;

        private ConsoleAppender()
        {
            this.messagesAppended = 0;
        }

        public ConsoleAppender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            Level level = error.Level;
            string message = error.Message;

            string formatted = String.Format(format, dateTime.ToString(dateFormat, CultureInfo.InvariantCulture), level.ToString(), message);

            Console.WriteLine(formatted);

            this.messagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}
