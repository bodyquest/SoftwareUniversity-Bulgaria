using System;
using System.Collections.Generic;
using System.Linq;

namespace Google
{
    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();

            while (input != "End")
            {
                string[] splittedInput = input.Split();
                string name = splittedInput[0];

                Person person = people.FirstOrDefault(x => x.Name == name);
                if (person == null)
                {
                    person = new Person(name);
                    people.Add(person);
                }

                if (splittedInput[1] == "company")
                {
                    string companyName = splittedInput[2];
                    string department = splittedInput[3];
                    string salary = splittedInput[4];

                    Company company = new Company(companyName, department, salary);
                    person.Company = company;
                }
                else if (splittedInput[1] == "car")
                {
                    string carModel = splittedInput[2];
                    int speed = int.Parse(splittedInput[3]);
                    Car car = new Car(carModel, speed);
                    person.Car = car;
                }
                else if (splittedInput[1] == "pokemon")
                {
                    string pokemonName = splittedInput[2];
                    string pokemonType = splittedInput[3];
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
                    
                    person.Pokemons.Add(pokemon);
                }
                else if (splittedInput[1] == "parents")
                {
                    string parentName = splittedInput[2];
                    string parentBirthDate = splittedInput[3];
                    Parent parent = new Parent(parentName, parentBirthDate);

                    person.Parents.Add(parent);
                }
                else if (splittedInput[1] == "children")
                {
                    string childName = splittedInput[2];
                    string childBirthDate = splittedInput[3];
                    Child child = new Child(childName, childBirthDate);

                    person.Children.Add(child);
                }

                input = Console.ReadLine();
            }

            string nameToPrint = Console.ReadLine();
            Person personToPrint = people.FirstOrDefault(p => p.Name == nameToPrint);
            Console.WriteLine(personToPrint.ToString());
        }
    }
}
