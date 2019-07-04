﻿namespace NeedForSpeed
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;
    }
}
