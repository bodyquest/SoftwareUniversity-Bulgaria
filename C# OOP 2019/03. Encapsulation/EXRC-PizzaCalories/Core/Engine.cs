namespace EXRC_PizzaCalories.Core
{
    using System;
    using System.Linq;

    using EXRC_PizzaCalories.Models;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];

                string[] doughInfo = Console.ReadLine().Split();

                string flourType = doughInfo[1];
                string bakeTechnique = doughInfo[2];
                double weight = double.Parse(doughInfo[3]);
                Dough dough = new Dough(flourType, bakeTechnique, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppingItems = input.Split().ToArray();

                    string type = toppingItems[1];
                    double toppingWeight = double.Parse(toppingItems[2]);

                    Topping topping = new Topping(type, toppingWeight);
                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
