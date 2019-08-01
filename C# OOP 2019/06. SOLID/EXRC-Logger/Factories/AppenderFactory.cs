namespace EXRC_Logger.Factories
{
    using System;

    using EXRC_Logger.Models;
    using EXRC_Logger.Exceptions;
    using EXRC_Logger.Models.Files;
    using EXRC_Logger.Models.Appenders;
    using EXRC_Logger.Models.Interfaces;
    using EXRC_Logger.Models.Enumerations;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level;
            bool hasParsed = Enum.TryParse<Level>(levelStr, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidAppenderTypeException();
            }

            return appender;
        }
    }
}
