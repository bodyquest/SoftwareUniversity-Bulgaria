using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Extension
{
    class CarCannotContinueException : Exception
    {
        public CarCannotContinueException(string message)
                : base(message)
        {
        }
    }
}

