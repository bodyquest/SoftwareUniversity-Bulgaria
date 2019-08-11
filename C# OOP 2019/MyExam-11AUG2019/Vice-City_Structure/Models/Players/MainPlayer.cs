using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        private const int LIFE_POINTS = 100;

        public MainPlayer(string name) 
            : base(name, LIFE_POINTS)
        {
        }
    }
}
