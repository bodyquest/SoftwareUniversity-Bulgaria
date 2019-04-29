using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Engine_And_Tires
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }


            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Power must be a positvie number.");
                }

                this.horsePower = value;
            }

        }
        public double CubicCapacity
        {
            get
            {
                return this.cubicCapacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity must be a positvie number.");
                }

                this.cubicCapacity = value;
            }
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
