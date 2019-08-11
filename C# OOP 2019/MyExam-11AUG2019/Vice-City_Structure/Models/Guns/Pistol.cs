using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int shotsPerRound = 1;
        private const int initialBulletsPerBarrel = 10;
        private const int totalBullets = 100;

        public Pistol(string name)
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
