using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster_BusinessLogic.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private const int DEFAULT_CAPACITY = 5;

        public Truck() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}
