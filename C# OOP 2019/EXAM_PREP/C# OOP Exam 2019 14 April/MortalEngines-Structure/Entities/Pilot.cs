using System;
using System.Text;
using System.Collections.Generic;

using MortalEngines.Common;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string name;
        private readonly List<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.PilotNameCannotBeNullOrEmpty);
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.NullMachineCannotBeAddedToPilot);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in this.machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
