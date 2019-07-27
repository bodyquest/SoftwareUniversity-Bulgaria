namespace StorageMaster.Entities.Storages
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using StorageMaster.Entities.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private const int CAPACITY = 1;
        private const int SLOTS = 2;
        private static Vehicle[] DEFAULT_VEHICLES = new Vehicle[]
        {
            new Truck()
        };

        public AutomatedWarehouse(string name) 
            : base(name, CAPACITY, SLOTS, DEFAULT_VEHICLES)
        {
        }
    }
}
