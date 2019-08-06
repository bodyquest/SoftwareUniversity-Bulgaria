using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Factories.Contracts
{
    public interface IMachinesFactory
    {
        IMachine CreateFactory();
    }
}
