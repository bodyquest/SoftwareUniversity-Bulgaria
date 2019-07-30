using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Items
{
    public class Toothbrush : Item
    {
        private const int Value = 3;

        public Toothbrush() 
            : base(Value)
        {
        }
    }
}
