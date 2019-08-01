namespace EXRC_FoodShortage.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_FoodShortage.Models;
    using EXRC_FoodShortage.Interfaces;

    public class Engine
    {
        private readonly List<IBuyer> checkpoint;

        public Engine()
        {
            this.checkpoint = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "End")
            {
                while (n-- > 0)
                {
                    string name = string.Empty;
                    int age;
                    string id = string.Empty;
                    string group = string.Empty;
                    string birthdate = string.Empty;

                    if (input.Length == 3)
                    {
                        AddRebel(input, out name, out age, out group);
                    }
                    else
                    {
                        AddCitizen(input, out name, out age, out id, out birthdate);
                    }

                    input = Console.ReadLine().Split(' ').ToArray();
                }

                string nameOfBuyer = input[0];
                IBuyer buyer = this.checkpoint.FirstOrDefault(b => b.Name == nameOfBuyer);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                input = Console.ReadLine().Split(' ').ToArray();
            }

            int result = checkpoint.Select(b => b.Food).Sum();

            Console.WriteLine(result);
        }

        private void AddCitizen(string[] input, out string name, out int age, out string id, out string birthdate)
        {
            name = input[0];
            age = int.Parse(input[1]);
            id = input[2];
            birthdate = input[3];

            IBuyer citizen = new Citizen(name, age, id, birthdate);
            this.checkpoint.Add(citizen);
        }

        private void AddRebel(string[] input, out string name, out int age, out string group)
        {
            name = input[0];
            age = int.Parse(input[1]);
            group = input[2];

            IBuyer rebel = new Rebel(name, age, group);
            this.checkpoint.Add(rebel);
        }
    }
}
