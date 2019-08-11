using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Common;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepo;

        protected Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = gunRepo;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(OutputMessages.PlayerNameCannotBeNullOrEmptySpace);
                }

                this.name = value;
            }
        }

        public int LifePoints
        {
            get => this.lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(OutputMessages.PlayerLifePointsCannotBeBelloZero);
                }

                this.lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository { get; private set; }


        public void TakeLifePoints(int points)
        {
            var expected = this.LifePoints -= points;
            if (expected < 0)
            {
                this.LifePoints = 0;
            }
            else
            {
                this.LifePoints -= points;
            }
        }

        public bool IsAlive => this.LifePoints <= 0;
    }
}
