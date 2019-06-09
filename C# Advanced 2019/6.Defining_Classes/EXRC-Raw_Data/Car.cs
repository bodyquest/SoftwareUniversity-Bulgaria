using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_Raw_Data
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car()
        {

        }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            if (tires.Length != 4)
            {
                throw new InvalidOperationException("Tires' quantity must be four.");
            }

            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tire[] Tires { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
