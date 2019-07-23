using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Contracts
{
    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }

        void Accommodate(IAnimal animal);

        void Adopt(string animalName, string owner);
    }
}
