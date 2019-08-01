namespace EXRC_BirthdayCelebrations.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_BorderControl.Models;
    using EXRC_BirthdayCelebrations.Interfaces;
    using EXRC_BirthdayCelebrations.Models;

    public class Engine
    {
        private readonly List<IBirthable> checkpoint;

        public Engine()
        {
            this.checkpoint = new List<IBirthable>();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "End")
            {
                string name = string.Empty;
                int age;
                string id = string.Empty;
                string birthdate = string.Empty;

                if(input[0].ToLower() == "citizen")
                {
                    AddCitizen(input, out name, out age, out id, out birthdate);
                }
                else if (input[0].ToLower() == "pet")
                {
                    AddPet(input, out name, out birthdate);
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            string yearOfBirth = Console.ReadLine();

            foreach (var entity in checkpoint)
            {
                if (entity.Birthdate.EndsWith(yearOfBirth))
                {
                    Console.WriteLine(entity.Birthdate.ToString());
                }
            }
        }

        private void AddPet(string[] input, out string name, out string birthdate)
        {
            name = input[1];
            birthdate = input[2];

            IBirthable pet = new Pet(name, birthdate);
            this.checkpoint.Add(pet);
        }

        private void AddCitizen(string[] input, out string name, out int age, out string id, out string birthdate)
        {
            name = input[1];
            age = int.Parse(input[2]);
            id = input[3];
            birthdate = input[4];

            IBirthable citizen = new Citizen(name, age, id, birthdate);
            this.checkpoint.Add(citizen);
        }
    }
}
