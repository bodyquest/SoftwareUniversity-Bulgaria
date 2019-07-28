namespace StorageMaster_BusinessLogic.Factories
{
    using System;

    using StorageMaster_BusinessLogic.Entities.Products;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product product = null;

            switch (type)
            {
                case "Ram":
                    product = new Ram(price);
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Gpu":
                    product = new Gpu(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}
