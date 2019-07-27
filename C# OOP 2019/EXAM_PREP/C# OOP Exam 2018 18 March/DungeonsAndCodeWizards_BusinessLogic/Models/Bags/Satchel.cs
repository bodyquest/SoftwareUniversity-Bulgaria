﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public class Satchel : Bag
    {
        private const int DEFAULT_CAPACITY = 20;

        public Satchel() 
            : base(DEFAULT_CAPACITY)
        {
        }
    }
}
