using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Semi : Vehicle
    {
        private const int DEFAULT_CAPACITY = 10;

        public Semi() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}
