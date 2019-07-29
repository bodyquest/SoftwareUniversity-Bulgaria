namespace FestivalManager.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Controllers;
    using IO.Contracts;
    using Controllers.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;

        private IReader reader;
        private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(
            IReader reader,
            IWriter writer,
            IFestivalController festivalCоntroller,
            ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                } 

                string commandResult;

                try
                {
                    commandResult = this.ProcessCommand(input);
                    
                }
                catch(TargetInvocationException ex)
                {
                    commandResult = "ERROR: " + ex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    commandResult = "ERROR: " + ex.Message;
                }

                this.writer.WriteLine(commandResult);
            }

            var end = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split();

            string command = tokens[0];
            string[] args = tokens
                .Skip(1)
                .ToArray();

            string result;

            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                var festivalControllerMethod = this.festivalCоntroller.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                result = (string)festivalControllerMethod
                .Invoke(this.festivalCоntroller, new object[] { args });
            }

            return result;
        }
		
	}
}