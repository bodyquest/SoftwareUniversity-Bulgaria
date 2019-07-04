namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.Fuel = fuel;
            this.HorsePower = horsePower;
        }

        public double Fuel { get; set; }

        public int HorsePower { get; set; }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public virtual void Drive(double kilometers)
        {
            double fuerlNeeded = this.FuelConsumption * kilometers;
            if (this.Fuel >= fuerlNeeded)
            {
                this.Fuel -= fuerlNeeded;
            }
        }
    }
}
