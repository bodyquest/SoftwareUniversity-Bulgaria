using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= AIR_CONDITION;
            return base.Drive(distance);
        }
    }
}
