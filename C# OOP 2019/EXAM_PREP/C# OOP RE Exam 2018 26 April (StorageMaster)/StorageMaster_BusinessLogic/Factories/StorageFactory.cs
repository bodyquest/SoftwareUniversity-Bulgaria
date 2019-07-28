namespace StorageMaster_BusinessLogic.Factories
{
    using System;

    using StorageMaster_BusinessLogic.Entities.Storages;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage storage = null;

            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
