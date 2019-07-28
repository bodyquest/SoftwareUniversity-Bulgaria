namespace StorageMaster_BusinessLogic.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using StorageMaster_BusinessLogic.Factories;
    using StorageMaster_BusinessLogic.Entities.Products;
    using StorageMaster_BusinessLogic.Entities.Storages;
    using StorageMaster_BusinessLogic.Entities.Vehicles;

    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new Dictionary<string, Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);

            if (!products.ContainsKey(type))
            {
                this.products.Add(type, new Stack<Product>());
            }

            this.products[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);

            this.storages[name] = storage;

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];

            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (var item in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!products.ContainsKey(item) || this.products[item].Count == 0)
                {
                    throw new InvalidOperationException($"{item} is out of stock!");
                }

                Product product = this.products[item].Pop();

                this.currentVehicle.Loadproduct(product);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage storage = this.storages[sourceName];
            Storage destinationStorage = this.storages[destinationName];
            Vehicle vehicle = storage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = storage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int trunkCapacity = vehicle.Trunk.Count();

            int unloadedCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedCount}/{trunkCapacity} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storages[storageName];

            Dictionary<string, int> productsAndCount = new Dictionary<string, int>();

            foreach (var product in storage.Products)
            {
                string productTypeName = product.GetType().Name;

                if (!productsAndCount.ContainsKey(productTypeName))
                {
                    productsAndCount.Add(productTypeName, 1);
                }
                else
                {
                    productsAndCount[productTypeName]++;
                }
            }

            //var sortedStorage = storage.Products.GroupBy(x => x.GetType().Name).OrderByDescending(x => x.Count()).ThenBy(x => x.GetType().Name);
            //.........................................................
            //Dictionary<string, int> sortedProducts = productsAndCount
            //    .OrderByDescending(p => p.Value)
            //    .ThenBy(p => p.Key)
            //    .ToDictionary(x => x.Key, x=> x.Value);

            //var productsAsString = new List<string>();

            //foreach (var item in sortedProducts)
            //{
            //    productsAsString.Add($"{item.Key} ({item.Value})");
            //}

            List<string> sortedProducts = productsAndCount
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Select(kvp => $"{kvp.Key} ({kvp.Value})")
                .ToList();

            double productsTotalWeight = storage.Products.Sum(p => p.Weight);

            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Stock ({0}/{1}): [{2}]", productsTotalWeight, storage.Capacity, (string.Join(", ", sortedProducts))));

            List<string> garageSlotsAsString = storage
                .Garage
                .Select(g => g == null ? "empty" : g.GetType().Name)
                .ToList();

            sb.AppendLine(String.Format("Garage: [{0}]", (string.Join("|", garageSlotsAsString))));

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var storage in storages.OrderByDescending(s => s.Value.Products.Sum(x => x.Price)))
            {
                string storageName = storage.Key;

                double storageWorth = storage
                    .Value
                    .Products
                    .Sum(p => p.Price);

                sb.AppendLine($"{storageName}:");
                sb.AppendLine($"Storage worth: ${storageWorth:f2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
