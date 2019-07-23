using System;

using AnimalCentre_Business_Logic.Core;
using AnimalCentre_Business_Logic.Core.Contracts;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
