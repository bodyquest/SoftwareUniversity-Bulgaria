namespace EXRC_Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQty = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public abstract double FuelQty { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public string Drive(double distance)
        {
            double needed = this.FuelConsumption * distance;

            if (this.FuelQty >= needed)
            {
                this.FuelQty -= needed;

                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public abstract void  Refuel(double fuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty:F2}";
        }
    }
}
