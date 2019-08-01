namespace EXRC_Vehicles.Models
{
    using EXRC_Vehicles;

    public class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;

        public Car(double fuelQty, double fuelConsum)
            :base(fuelQty, fuelConsum)
        {
            this.FuelConsumption += AIR_CONDITION;
        }

        public override double FuelQty { get; protected set; }

        public override void Refuel(double fuel)
        {
            this.FuelQty += fuel;
        }
    }
}
