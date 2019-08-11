using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun, IGun
    {
        private const int shotsPerRound = 5;
        private const int initialBulletsPerBarrel = 50;
        private const int totalBullets = 500;

        public Rifle(string name)
            : base(name, initialBulletsPerBarrel, totalBullets)
        {
        }

        public override int Fire()
        {

            this.BulletsPerBarrel -= shotsPerRound;

            if (BulletsPerBarrel == 0)
            {
                this.BulletsPerBarrel += initialBulletsPerBarrel;
                this.TotalBullets -= initialBulletsPerBarrel;
            }
            return shotsPerRound;
        }
    }
}
