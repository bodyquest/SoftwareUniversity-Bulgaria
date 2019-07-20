using System;

namespace EXRC_VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQty;

        protected Vehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQty = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public int TankCapacity { get; private set; }

        public double FuelQty
        {
            get => this.fuelQty;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQty = 0;
                }
                else
                {
                    this.fuelQty = value;
                }
            }
        }

        public double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double needed = this.FuelConsumption * distance;
            string vehicleName = this.GetType().Name;

            if (this.FuelQty >= needed)
            {
                this.FuelQty -= needed;

                return $"{vehicleName} travelled {distance} km";
            }

            return $"{vehicleName} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            } 

            double totalFuelQty = this.FuelQty + fuel;
             
            if (totalFuelQty > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQty += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:F2}";
        }
    }
}
