using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AnimalCentre
{
    public class Hotel : IHotel
    {
        private const int CAPACITY = 10;

        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();

        }

        public IReadOnlyDictionary<string, IAnimal> Animals => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == CAPACITY)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exists");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;

            animals.Remove(animalName);
        }

    }
}
