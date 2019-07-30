using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Jewelery : Item
    {
        private const int Value = 300;

        public Jewelery() 
            : base(Value)
        {
        }
    }
}
