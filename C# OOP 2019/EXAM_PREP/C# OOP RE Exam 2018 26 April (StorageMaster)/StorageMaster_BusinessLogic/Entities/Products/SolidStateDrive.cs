using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster_BusinessLogic.Entities.Products
{
    public class SolidStateDrive : Product
    {
        private const double DEFAULT_WEIGHT = 0.2;

        public SolidStateDrive(double price) 
            : base(price, DEFAULT_WEIGHT)
        {
        }
    }
}
