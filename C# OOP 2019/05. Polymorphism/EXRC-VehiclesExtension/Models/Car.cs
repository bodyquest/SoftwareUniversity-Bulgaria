namespace EXRC_VehiclesExtension.Models
{
    using EXRC_VehiclesExtension;

    public class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;

        public Car(double fuelQty, double fuelConsum, int tankCapacity)
            :base(fuelQty, fuelConsum + AIR_CONDITION, tankCapacity)
        {
        }
    } 
}
