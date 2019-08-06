namespace MortalEngines.Core
{
    using Contracts;
    using System.Linq;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Factories;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilots;
        private readonly List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"{string.Format(OutputMessages.PilotExists, name)}";
            }

            var pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return $"{string.Format(OutputMessages.PilotHired, name)}";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"{string.Format(OutputMessages.MachineExists, name)}";
            }

            var tank = (ITank)TankFactory.CreateTank(name, attackPoints, defensePoints);
            //tank.ToggleDefenseMode();
            this.machines.Add(tank);

            return $"{string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints)}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"{string.Format(OutputMessages.MachineExists, name)}";
            }

            var fighter = (IFighter)FighterFactory.CreateFighter(name, attackPoints, defensePoints);
            //fighter.ToggleAggressiveMode();
            this.machines.Add(fighter);

            return $"{string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, (fighter.AggressiveMode == true ? "ON" : "OFF"))}";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.Any(p => p.Name == selectedPilotName))
            {
                return $"{string.Format(OutputMessages.PilotNotFound, selectedPilotName)}";
            }

            if (!this.machines.Any(m => m.Name == selectedMachineName))
            {
                return $"{string.Format(OutputMessages.MachineNotFound, selectedMachineName)}";
            }

            var machine = this.machines.First(m => m.Name == selectedMachineName);

            if (machine.Pilot != null)
            {
                return $"{string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName)}";
            }

            var pilot = this.pilots.First(p => p.Name == selectedPilotName);

            pilot.AddMachine(machine);
            machine.Pilot = pilot;

            return $"{string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName)}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.Any(m => m.Name == attackingMachineName) 
                || !this.machines.Any(m => m.Name == defendingMachineName))
            {
                if (!this.machines.Any(m => m.Name == attackingMachineName))
                {
                    return $"{string.Format(OutputMessages.MachineNotFound, attackingMachineName)}";
                }
                else if (!this.machines.Any(m => m.Name == defendingMachineName))
                {
                    return $"{string.Format(OutputMessages.MachineNotFound, defendingMachineName)}";
                }
            }

            var attacker = this.machines.First(m => m.Name == attackingMachineName);
            var defender = this.machines.First(m => m.Name == defendingMachineName);

            if (attacker.HealthPoints <= 0 || defender.HealthPoints <= 0)
            {
                if (attacker.HealthPoints == 0)
                {
                    return $"{string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName)}";
                }
                else if (defender.HealthPoints == 0)
                {
                    return $"{string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName)}";
                }
            }

            attacker.Attack(defender);
            return $"{string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints)}";
        }

        public string PilotReport(string pilotReporting)
        {
            if (!this.pilots.Any(p => p.Name == pilotReporting))
            {
                return $"{string.Format(OutputMessages.PilotNotFound, pilotReporting)}";
            }

            var pilot = this.pilots.First(p => p.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            if (!this.machines.Any(m => m.Name == machineName))
            {
                return string.Format(OutputMessages.MachineNotFound, machineName);
            }

            var machine = this.machines.First(p => p.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!this.machines.Any(m => m.Name == fighterName))
            {
                return $"{string.Format(OutputMessages.MachineNotFound, fighterName)}";
            }

            var fighter = (IFighter)this.machines.First(m => m.Name == fighterName);
            fighter.ToggleAggressiveMode();

            return $"{string.Format(OutputMessages.FighterOperationSuccessful, fighterName)}";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (!this.machines.Any(m => m.Name == tankName))
            {
                return $"{string.Format(OutputMessages.MachineNotFound, tankName)}";
            }

            var tank = (ITank)this.machines.First(m => m.Name == tankName);
            tank.ToggleDefenseMode();

            return $"{string.Format(OutputMessages.TankOperationSuccessful, tankName)}";
        }
    }
}