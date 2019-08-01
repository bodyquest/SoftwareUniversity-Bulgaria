namespace EXRC_PizzaCalories.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using EXRC_PizzaCalories.Exceptions;

    public class Pizza
    {
        private const int MIN_NAME_LENGTH = 1;
        private const int MAX_NAME_LENGTH = 15;
        private const int MAX_TOPPINGS_COUNT = 10;

        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || (value.Length < 1 || value.Length > 15))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidPizzaNameLengthException, MIN_NAME_LENGTH.ToString(), MAX_NAME_LENGTH.ToString()));
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;
            private set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MAX_TOPPINGS_COUNT)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidToppingsCount, MAX_TOPPINGS_COUNT));
            }
            else
            {
                this.toppings.Add(topping);
            }
        }

        public override string ToString()
        {
            double totalCalories = this.dough.Calories() + this.toppings.Sum(t => t.Calories());
            return $"{this.Name} - {totalCalories:f2} Calories."; 
        }
    }
}
