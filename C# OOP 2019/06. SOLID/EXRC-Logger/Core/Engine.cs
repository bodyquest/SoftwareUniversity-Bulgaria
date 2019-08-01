namespace EXRC_Logger.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using EXRC_Logger.Factories;
    using EXRC_Logger.Models.Interfaces;

    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command!="END")
            {
                var errorArgs = command.Split("|").ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
