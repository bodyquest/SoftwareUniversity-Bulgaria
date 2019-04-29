using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Engine_And_Tires
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private Engine engine;
        private Tire[] tire;
        private double fuelQuantity;
        private double fuelConsumption;

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Car must be more than 1 symbol.");
                }

                this.Make = value; 
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Car model must be more than 1 symbol.");
                }

                this.Model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            private set
            {
                var maxYear = DateTime.Now.Year;
                if (value < 1900 || value > maxYear)
                {
                    throw new ArgumentException("The year msut be a positive number");
                }

                this.Year = value;
            }
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            var canContinue = this.FuelQuantity - this.FuelConsumption * distance >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
            }
            else
            {
                throw new ArgumentNullException("Not enough fuel!");
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.engine), "Engine cannot be null.");
                }

                this.engine = value;
            }
        }

        public Tire [] Tire
        {
            get
            {
                return this.tire;
            }
            set
            {
                this.tire = value;
            }
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        public Car (string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tire = tires;
        }
    }
}
