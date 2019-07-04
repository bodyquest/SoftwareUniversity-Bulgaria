﻿namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;

        private const decimal CoffeePrice = 3.5m;

        public Coffee(string name, double caffeine)
            : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
