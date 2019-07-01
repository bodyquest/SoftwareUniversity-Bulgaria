namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EngineFactory
    {
        public Engine Create(int speed, int power)
        {
            return new Engine(speed, power);
        }
    }
}
