using EXRC_ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_ExplicitInterfaces.Core
{
    public class Engine
    {
        private readonly List<IPerson> people;

        public Engine()
        {
            this.people = new List<IPerson>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] data = input.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);

                IPerson person = new Citizen(name, country, age);
                this.people.Add(person);


                input = Console.ReadLine();
            }

            foreach (IPerson citizen in people)
            {
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
