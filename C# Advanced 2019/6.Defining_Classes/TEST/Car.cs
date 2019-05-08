using System;
using System.Collections.Generic;
using System.Text;

namespace TEST
{
    public class Car
    {
        private string make;
        private string model;
        private int year;

        // CONSTRUCTOR /////////////////////////////////////
        // when object is initialized, what is in the consturctor gets created
        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        ////////////////////////////////////////////////////
        // there can be more than ONE constructor in the class !!!
        //////////////////////////////////////////////////////////
        
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
                if (value.Length < 1 || value.Length > 20)
                {
                    throw new ArgumentException("Car model can't be less than 1 symbol or more than 20 symbols long.");
                }

                this.model = value;
            }
        }

        public int Year
        {
            get { return this.year; }

            private set
            {
                var maxYear = DateTime.Now.Year;
                if (value < 1900 || value > maxYear)
                {
                    throw new ArgumentException("Car year must be between 1900 and this year.");
                }

                this.year = value;
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
                throw new InvalidOperationException("Not enough fuel!");
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
