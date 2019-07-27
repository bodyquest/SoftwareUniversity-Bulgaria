namespace StorageMaster.Entities.Storages
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;

    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle [] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.products = new List<Product>();
            this.garage = new Vehicle[this.GarageSlots];

            this.FillGarageWithVehicles(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection <Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            int foundGarageSlotIndex = deliveryLocation.AddVehicleToGarage(vehicle);

            this.garage[garageSlot] = null;

            return foundGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            int numberOfUnloadedProducts = 0;

            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                this.products.Add(vehicle.Unload());
                numberOfUnloadedProducts++;
            }

            return numberOfUnloadedProducts;
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeSlotNumber = Array.IndexOf(this.garage, null);
            if (freeSlotNumber == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[freeSlotNumber] = vehicle;

            return freeSlotNumber;
        }

        private void FillGarageWithVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;
            foreach (var vehicle in vehicles)
            {
                this.garage[index++] = vehicle;
                
            }
        }
    }
}
