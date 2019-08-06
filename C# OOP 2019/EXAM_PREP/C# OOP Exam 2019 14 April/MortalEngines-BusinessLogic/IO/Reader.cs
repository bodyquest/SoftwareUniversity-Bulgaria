namespace MortalEngines.IO
{
    using System;

    using Contracts;

    public class Reader : IReader
    {
        public string ReadCommands()
        {
            return Console.ReadLine();
        }
    }
}
