namespace MortalEngines
{
    using System;
    using MortalEngines.IO;
    using MortalEngines.Core;
    using MortalEngines.Factories;
    using System.Collections.Generic;
    using MortalEngines.Entities.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new Reader();
            var writer = new Writer();
            var machineController = new MachinesManager();

            var machines = new List<IMachine>();
            var pilots = new List<IPilot>();

            var tankFactory = new TankFactory();
            var fighterFactory = new FighterFactory();


            var engine = new Engine(reader, writer, machineController);

            engine.Run();

            
        }
    }
}