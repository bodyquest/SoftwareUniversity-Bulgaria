namespace EXRC_BorderControl.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_BorderControl.Models;
    using EXRC_BorderControl.Interfaces;

    public class Engine
    {
        private readonly List<IIdentifiable> checkpoint;

        public Engine()
        {
            this.checkpoint = new List<IIdentifiable>();
        }

        public void Run()
        {
            var input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "End")
            {
                string name = string.Empty;
                string model = string.Empty;
                int age;
                string id = string.Empty;

                if (input.Length == 2)
                {
                    AddRobot(input, out model, out id);
                }
                else
                {
                    AddCitizen(input, out name, out age, out id);
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            string fakeId = Console.ReadLine();

            foreach (var entity in checkpoint)
            {
                if (entity.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(entity.Id.ToString());
                }
            }
        }

        private void AddCitizen(string[] input, out string name, out int age, out string id)
        {
            name = input[0];
            age = int.Parse(input[1]);
            id = input[2];

            IIdentifiable citizen = new Citizen(name, age, id);
            this.checkpoint.Add(citizen);
        }

        private void AddRobot(string[] input, out string model, out string id)
        {
            model = input[0];
            id = input[1];

            IIdentifiable robot = new Robot(model, id);
            this.checkpoint.Add(robot);
        }
    }
}
