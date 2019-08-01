namespace EXRC_WildFarm
{
    using System;
    using System.Collections.Generic;

    using EXRC_WildFarm.Models.Animals;
    using EXRC_WildFarm.Models.Foods;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (input != "End")
            {
                string[] animalInfo = input.Split();

                Animal animal = AnimalFactory.Create(animalInfo);

                string[] foodInfo = Console.ReadLine().Split();

                Food food = FoodFactory.Create(foodInfo);

                Console.WriteLine(animal.AskForFood());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
