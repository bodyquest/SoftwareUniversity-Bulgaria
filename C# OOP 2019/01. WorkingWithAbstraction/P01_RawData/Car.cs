namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; private set; }

        public Cargo Cargo { get; private set; }

        public Tire[] Tires { get; private set; }

    }   
}
