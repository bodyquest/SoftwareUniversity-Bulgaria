using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public abstract class Product
    {
        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return price; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public double Weight { get; private set; }
    }
}
