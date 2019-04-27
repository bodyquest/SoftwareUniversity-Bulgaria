using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    class Car
    {
        private string make;
        private string model;
        public Car( string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public string Make
        {
            get { return this.make;  }

            private set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Car make must be more than 1 symbol");
                }
                this.make = value;
            }

        }
        public string Model
        {
            get { return this.model; }
            private set
            {
                this.model = value;
            }
        }
        public int Year { get; private set; }
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
                throw new CarCannotContinueException("Not enough fuel!");
            }
        }
        public string GetInformation()
        {
            var result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.Append($"Fuel: {this.FuelQuantity:F2}L");
            return result.ToString();
        }
    }
}
