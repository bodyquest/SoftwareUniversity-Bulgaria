namespace EXRC_Logger
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_Logger.Core;
    using EXRC_Logger.Models;
    using EXRC_Logger.Factories;
    using EXRC_Logger.Models.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppenderFactory appenderfactory = new AppenderFactory();
            ReadAppenderData(appendersCount, appenders, appenderfactory);

            ILogger logger = new Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
        }

        private static void ReadAppenderData(int appendersCount, ICollection<IAppender> appenders, AppenderFactory appenderfactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string [] appendersInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderfactory.GetAppender(appenderType, layoutType, levelStr);

                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            }
        }
    }
}
