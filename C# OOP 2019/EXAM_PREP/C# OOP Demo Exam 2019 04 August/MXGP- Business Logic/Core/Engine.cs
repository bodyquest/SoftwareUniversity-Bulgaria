namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MXGP.Core.Contracts;
    using MXGP.IO.Contracts;

    public class Engine : IEngine
    {
        private const string CreateRider = "CreateRider";
        private const string CreateMotorcycle = "CreateMotorcycle";
        private const string AddMotorcycleToRider = "AddMotorcycleToRider";
        private const string AddRiderToRace = "AddRiderToRace";
        private const string CreateRace = "CreateRace";
        private const string StartRace = "StartRace";

        private IReader reader;
        private IWriter writer;

        private IChampionshipController controller;

        public Engine(IReader reader, IWriter writer, IChampionshipController controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            string input = reader.ReadLine();

            while (!input.Equals("End"))
            {

                string commandResult;

                try
                {
                    commandResult = this.ProcessCommand(input);
                    writer.WriteLine(commandResult);

                }
                catch (TargetInvocationException ex)
                {
                    commandResult = ex.InnerException.Message;
                    writer.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    commandResult = ex.Message;
                    writer.WriteLine(commandResult);
                }

                input = reader.ReadLine();
            }
        }

        private string ProcessCommand(string input)
        {
            var tokens = input.Split();

            string command = tokens[0];
            string[] args = tokens
                .Skip(1)
                .ToArray();

            string result = string.Empty;

            // if-else checks for commands

            if (command.Equals(CreateRider))
            {
                result = this.controller.CreateRider(args[0]);
            }
            else if (command.Equals(CreateMotorcycle))
            {
               result = this.controller.CreateMotorcycle(args[0], args[1], int.Parse(args[2]));
            }
            else if (command.Equals(AddMotorcycleToRider))
            {
                result = this.controller.AddMotorcycleToRider(args[0], args[1]);
            }
            else if (command.Equals(AddRiderToRace))
            {
                result = this.controller.AddRiderToRace(args[0], args[1]);
            }
            else if (command.Equals(CreateRace))
            {
                result = this.controller.CreateRace(args[0], int.Parse(args[1]));
            }
            else if (command.Equals(StartRace))
            {
                result = this.controller.StartRace(args[0]);
            }

            return result;
        }
    }
}
