using System;
using System.Collections.Generic;
using System.Text;

namespace Speed_Racing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double distance;

        public Car()
        {
            Model = this.model;
            FuelAmount = this.fuelAmount;
            FuelConsumption = this.fuelConsumption;
            this.Distance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; }

        public static bool canDrive(Car car, double distance )
        {
            var kilometers = car.FuelAmount / car.FuelConsumption;

            if (kilometers >= distance)
            {
                car.FuelAmount -= car.FuelConsumption * distance;
                car.Distance += distance;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {(int)Distance}"; ; 
        }
    }
}
