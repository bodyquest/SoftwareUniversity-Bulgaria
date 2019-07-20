namespace EXRC_VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        private const double FUEL_AMOUNT_MODIFIER = 0.05;

        public Truck(double fuelQty, double fuelConsum, int tankCapacity)
            : base (fuelQty, fuelConsum + AIR_CONDITION, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQty -= fuel * FUEL_AMOUNT_MODIFIER;
        }
    }
}
