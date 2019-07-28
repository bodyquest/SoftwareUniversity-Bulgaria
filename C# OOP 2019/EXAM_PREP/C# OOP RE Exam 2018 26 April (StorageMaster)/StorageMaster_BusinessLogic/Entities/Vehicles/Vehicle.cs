namespace StorageMaster_BusinessLogic.Entities.Vehicles
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using StorageMaster_BusinessLogic.Entities.Products;

    public abstract class Vehicle
    {
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        // TODO check if correct calculated property
        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return this.trunk.AsReadOnly();
            }
        }

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public virtual void Loadproduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public virtual Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk.Last(); // TODO check if this works or use:  this.trunk[this.trunk.Count -1];
            this.trunk.RemoveAt(this.trunk.Count -1);

            return product;
        }
    }
}
