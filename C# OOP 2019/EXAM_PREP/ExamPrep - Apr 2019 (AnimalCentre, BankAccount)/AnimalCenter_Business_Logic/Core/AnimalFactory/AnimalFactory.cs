using System;
using System.Linq;
using System.Reflection;

using AnimalCentre.Models.Contracts;

namespace AnimalCentre_Business_Logic.Core.AnimalFactory
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var animal = (IAnimal)Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);

            return animal;
        }
    }
}
