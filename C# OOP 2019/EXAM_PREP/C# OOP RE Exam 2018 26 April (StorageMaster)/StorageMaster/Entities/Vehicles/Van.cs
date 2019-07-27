using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public class Van : Vehicle
    {
        private const int DEFAULT_CAPACITY = 2;

        public Van() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}
