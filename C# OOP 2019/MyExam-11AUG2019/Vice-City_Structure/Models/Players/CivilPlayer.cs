using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player, IPlayer
    {
        private const int LIFE_POINTS = 50;

        public CivilPlayer(string name)
            : base(name, LIFE_POINTS)
        {
        }
    }
}
