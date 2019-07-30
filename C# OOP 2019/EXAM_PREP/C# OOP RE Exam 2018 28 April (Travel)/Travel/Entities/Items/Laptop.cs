using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Laptop : Item
    {
        private const int Value = 3000;

        public Laptop() 
            : base(Value)
        {
        }
    }
}
