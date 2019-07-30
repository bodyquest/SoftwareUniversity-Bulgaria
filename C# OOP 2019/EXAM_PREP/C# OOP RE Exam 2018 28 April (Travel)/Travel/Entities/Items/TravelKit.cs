using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class TravelKit : Item
    {
        private const int Value = 30;

        public TravelKit() 
            : base(Value)
        {
        }
    }
}
