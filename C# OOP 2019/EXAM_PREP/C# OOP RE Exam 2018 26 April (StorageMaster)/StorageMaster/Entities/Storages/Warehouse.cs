namespace StorageMaster.Entities.Storages
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    using StorageMaster.Entities.Vehicles;

    public class Warehouse : Storage
    {
        private const int CAPACITY = 10;
        private const int SLOTS = 10;
        private static Vehicle[] DEFAULT_VEHICLES = new Vehicle[]
        {
            new Semi(),
            new Semi(),
            new Semi()
        };

        public Warehouse(string name)
            : base(name, CAPACITY, SLOTS, DEFAULT_VEHICLES)
        {
        }
    }
}
