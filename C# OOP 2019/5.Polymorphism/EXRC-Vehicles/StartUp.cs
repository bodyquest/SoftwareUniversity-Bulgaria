using EXRC_Vehicles.Core;
using System;

namespace EXRC_Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
