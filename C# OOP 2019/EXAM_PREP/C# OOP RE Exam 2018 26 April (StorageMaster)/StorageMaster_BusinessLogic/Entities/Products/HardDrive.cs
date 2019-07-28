using System;
using System.Text;
using System.Collections.Generic;

namespace StorageMaster_BusinessLogic.Entities.Products
{
    public class HardDrive : Product
    {
        private const double DEFAULT_WEIGHT = 1;
        public HardDrive(double price) 
            : base(price, DEFAULT_WEIGHT)
        {
        }
    }
}
