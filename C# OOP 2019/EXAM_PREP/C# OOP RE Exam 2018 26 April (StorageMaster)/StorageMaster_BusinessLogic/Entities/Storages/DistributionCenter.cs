namespace StorageMaster_BusinessLogic.Entities.Storages
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using StorageMaster_BusinessLogic.Entities.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int CAPACITY = 2;
        private const int SLOTS = 5;
        private static Vehicle[] DEFAULT_VEHICLES = new Vehicle[]
        {
            new Van(),
            new Van(),
            new Van()
        };

        public DistributionCenter(string name)
            : base(name, CAPACITY, SLOTS, DEFAULT_VEHICLES)
        {
        }
    }
}
