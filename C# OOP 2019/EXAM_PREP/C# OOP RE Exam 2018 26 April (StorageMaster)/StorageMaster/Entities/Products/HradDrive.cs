using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Products
{
    public class HradDrive : Product
    {
        private const double DEFAULT_WEIGHT = 1;
        public HradDrive(double price) 
            : base(price, DEFAULT_WEIGHT)
        {
        }
    }
}
