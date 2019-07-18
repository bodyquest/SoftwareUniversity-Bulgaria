using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_ExplicitInterfaces.Interfaces
{
    public interface IResident
    {
        string Name { get; }

        string Country { get; }

        string GetName();
    }
}
