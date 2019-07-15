namespace EXRC_PizzaCalories.Models
{
    using System;

    using EXRC_PizzaCalories.Exceptions;

    public class Topping
    {
        private const double BASE_CALORIES = 2.0;
        private const double MIN_TOPPING_WEIGHT = 1;
        private const double MAX_TOPPING_WEIGHT = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidToppingTypeException, value));
                }

                this.type = value;
            }
        }

        public  double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MIN_TOPPING_WEIGHT || value > MAX_TOPPING_WEIGHT)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidToppingWeightException, this.type));
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            double modifier = BASE_CALORIES;
            modifier = ModifyToppingCalories(modifier);

            return modifier * this.Weight;
        }

        private double ModifyToppingCalories(double modifier)
        {
            switch (this.Type.ToLower())
            {
                case "meat": modifier *= 1.2; break;
                case "veggies": modifier *= 0.8; break;
                case "cheese": modifier *= 1.1; break;
                case "sauce": modifier *= 0.9; break;
                default:
                    break;
            }

            return modifier;
        }
    }
}
