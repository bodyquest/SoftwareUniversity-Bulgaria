using EXRC_VehiclesExtension.Core;
using System;

namespace EXRC_VehiclesExtension
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
