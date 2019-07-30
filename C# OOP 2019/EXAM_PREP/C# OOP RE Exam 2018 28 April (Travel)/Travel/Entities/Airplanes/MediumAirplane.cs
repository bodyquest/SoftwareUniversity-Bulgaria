using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int PLANE_SEATS = 10;
        private const int BAGCOMPARTMENTS = 14;

        public MediumAirplane() 
            : base(PLANE_SEATS, BAGCOMPARTMENTS)
        {
        }
    }
}
