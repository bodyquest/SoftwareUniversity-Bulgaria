using System;
using System.Text;
using System.Collections.Generic;

using MXGP.Core.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            throw new NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new NotImplementedException();
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            throw new NotImplementedException();
        }

        public string CreateRace(string name, int laps)
        {
            throw new NotImplementedException();
        }

        public string CreateRider(string riderName)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
