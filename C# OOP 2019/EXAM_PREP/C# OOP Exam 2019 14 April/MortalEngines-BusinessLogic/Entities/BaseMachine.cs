using MortalEngines.Common;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.MachineNameCannotBeNullOrEmpty);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(ExceptionMessages.PilotCannotBeNull);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }


        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.TargetCannotBeNull);
            }

            double difference = Math.Abs(this.AttackPoints - this.DefensePoints);
            

            if (target.HealthPoints - difference < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= difference;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"- {this.Name}");
            result.AppendLine($" *Type: {this.GetType().Name}");
            result.AppendLine($" *Health: {this.HealthPoints:f2}");
            result.AppendLine($" *Attack: {this.AttackPoints:f2}");
            result.AppendLine($" *Defence: {this.DefensePoints:f2}");

            if (this.Targets.Count == 0)
            {
                result.AppendLine($" * Targets: None");
            }
            else
            {
                result.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
