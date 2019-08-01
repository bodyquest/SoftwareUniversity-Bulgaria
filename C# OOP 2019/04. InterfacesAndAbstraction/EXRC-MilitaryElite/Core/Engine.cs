namespace EXRC_MilitaryElite.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_MilitaryElite.Models;
    using EXRC_MilitaryElite.Contracts;
    using EXRC_MilitaryElite.Exceptions;
    using EXRC_MilitaryElite.Enumerations;

    public class Engine
    {
        private readonly List<ISoldier> army;
        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = System.Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split(" ")
                    .ToArray();

                string type = commandArgs[0];
                string id = commandArgs[1];
                string firstName = commandArgs[2];
                string lastName = commandArgs[3];
                decimal salary = decimal.Parse(commandArgs[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);

                    this.army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesToAddArgs = commandArgs
                        .Skip(5)
                        .ToArray();

                    foreach (var pid in privatesToAddArgs)
                    {
                        ISoldier soldierToAdd = this.army
                            .First(s => s.Id == pid);

                        general.AddPrivate(soldierToAdd);
                    }

                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        AddRepairs(engineer, repairArgs);

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException)
                    {
                    }
                    
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = commandArgs[5];

                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionArgs = commandArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missionArgs.Length -1; i+=2)
                        {
                            try
                            {
                                string codeName = missionArgs[i];
                                string state = missionArgs[i + 1];

                                IMission mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException)
                            {
                                continue;
                            }
                        }

                        this.army.Add(commando);
                    }
                    catch (InvalidCorpsException)
                    {
                    }
                    
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;
                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    this.army.Add(spy);
                }

                command = System.Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();
                Object actual = Convert.ChangeType(soldier, type);

                Console.WriteLine(actual.ToString());
;            }
        }

        private static void AddRepairs(IEngineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length - 1; i += 2)
            {
                string partName = repairArgs[i];
                int hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }
        }
    }
}
