namespace MortalEngines.IO
{
    using System;

    using Contracts;

    public class Writer : IWriter
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}
