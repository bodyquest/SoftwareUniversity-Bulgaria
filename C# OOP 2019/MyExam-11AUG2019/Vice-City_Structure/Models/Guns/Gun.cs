using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Common;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.GunNameCannotBeNullOrEmptySpace);
                }

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => this.bulletsPerBarrel;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(OutputMessages.BulletscanotBeBellowZero);
                }

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => this.totalBullets;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(OutputMessages.TotalBulletscanotBeBellowZero);
                }

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.TotalBullets > 0;

        //TODO FIRE GUN
        public abstract int Fire();
        

    }
}
