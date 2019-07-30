using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Airplanes
{
    public class LigthAirplane : Airplane
    {
        private const int PLANE_SEATS = 5;
        private const int BAGCOMPARTMENTS = 8;

        public LigthAirplane()
            : base(PLANE_SEATS, BAGCOMPARTMENTS)
        {
        }
    }
}
