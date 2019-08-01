namespace EXRC_Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        private const double FUEL_AMOUNT_MODIFIER = 0.95;

        private double fuelConsumption;

        public Truck(double fuelQty, double fuelConsum)
            : base(fuelQty, fuelConsum)
        {
            this.FuelConsumption += AIR_CONDITION;
        }

        public override double FuelQty { get; protected set; }

        public override void Refuel(double fuel)
        {
            this.FuelQty += fuel * FUEL_AMOUNT_MODIFIER;
        }
    }
}
