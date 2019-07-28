using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster_BusinessLogic.Entities.Products
{
    public class Gpu : Product
    {
        private const double DEFAULT_WEIGHT = 0.7;
        public Gpu(double price) 
            : base(price, DEFAULT_WEIGHT)
        {
        }
    }
}
