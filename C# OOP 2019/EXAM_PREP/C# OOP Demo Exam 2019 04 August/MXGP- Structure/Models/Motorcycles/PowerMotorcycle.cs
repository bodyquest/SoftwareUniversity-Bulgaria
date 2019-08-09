﻿using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle, IMotorcycle
    {
        private const double CC = 450;
        private const int minHP = 70;
        private const int maxHP = 100;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CC)
        {
        }

        public override int HorsePower
        {
            get => this.horsePower;
            protected set
            {
                if (value < minHP || value > maxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower  = value;
            }
        }
    }
}
