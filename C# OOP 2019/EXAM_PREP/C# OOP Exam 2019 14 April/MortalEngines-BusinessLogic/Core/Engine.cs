namespace MortalEngines.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Collections.Generic;

    using MortalEngines.IO.Contracts;
    using MortalEngines.Core.Contracts;

    public class Engine : IEngine
    {
        private const string Quit = "Quit";
        private const string HirePilot = "HirePilot";
        private const string ManufactureTank = "ManufactureTank";
        private const string ManufactureFighter = "ManufactureFighter";
        private const string EngageMachine = "Engage";
        private const string AttackMachines = "Attack";
        private const string PilotReport = "PilotReport";
        private const string MachineReport = "MachineReport";
        private const string ToggleFighterAggressiveMode = "AggressiveMode";
        private const string ToggleTankDefenseMode = "DefenseMode";

        private IReader reader;
        private IWriter writer;

        private IMachinesManager machineController;

        public Engine(IReader reader, IWriter writer, IMachinesManager machineController)
        {
            this.reader = reader;
            this.writer = writer;
            this.machineController = machineController;
        }

        public void Run()
        {
            string input = reader.ReadCommands();

            while (!input.Equals(Quit))
            {

                string commandResult;

                try
                {
                    commandResult = this.ProcessCommand(input);
                    writer.Write(commandResult);

                }
                catch (TargetInvocationException ex)
                {
                    commandResult = "Error: " + ex.InnerException.Message;
                    writer.Write(commandResult);
                }
                catch (Exception ex)
                {
                    commandResult = "Error: " + ex.Message;
                    writer.Write(commandResult);
                }

                input = reader.ReadCommands();
            }
        }

        private string ProcessCommand(string input)
        {
            var tokens = input.Split();

            string command = tokens[0];
            string[] args = tokens
                .Skip(1)
                .ToArray();

            string result;

            if (command.Equals(HirePilot))
            {
                result = this.machineController.HirePilot(tokens[1]);
            }
            else if (command.Equals(ManufactureTank))
            {
                result = this.machineController.ManufactureTank(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
            }
            else if (command.Equals(ManufactureFighter))
            {
                result = this.machineController.ManufactureFighter(tokens[1], double.Parse(tokens[2]), double.Parse(tokens[3]));
            }
            else if (command.Equals(EngageMachine))
            {
                result = this.machineController.EngageMachine(tokens[1], tokens[2]);
            }
            else if (command.Equals(AttackMachines))
            {
                result = this.machineController.AttackMachines(tokens[1], tokens[2]);
            }
            else if (command.Equals(PilotReport))
            {
                result = this.machineController.PilotReport(tokens[1]);
            }
            else if (command.Equals(MachineReport))
            {
                result = this.machineController.MachineReport(tokens[1]);
            }
            else if (command.Equals(ToggleFighterAggressiveMode))
            {
                result = this.machineController.ToggleFighterAggressiveMode(tokens[1]);
            }
            else
            {
                result = this.machineController.ToggleTankDefenseMode(tokens[1]);
            }

            return result;
        }
    }
}