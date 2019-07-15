namespace EXRC_PizzaCalories.Models
{
    using System;

    using EXRC_PizzaCalories.Exceptions;

    public class Dough
    {
        private const double BASE_CALORIES = 2.0;
        private const double MIN_WEIGHT_VALUE = 1;
        private const double MAX_WEIGHT_VALUE = 200;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flour, string technique, double weight)
        {
            this.FlourType = flour;
            this.BakingTechnique = technique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                    
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" 
                    && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughTypeException);
                    
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MIN_WEIGHT_VALUE || value > MAX_WEIGHT_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeightException);
                }

                this.weight = value;
            }
        }

        public double Calories()
        {
            double modifier = BASE_CALORIES;
            modifier = ModifyFlourTypeCalories(modifier);
            modifier = ModifyBakeTechniqueCalories(modifier);

            return modifier * this.Weight;
        }

        private double ModifyBakeTechniqueCalories(double modifier)
        {
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy": modifier *= 0.9; break;
                case "chewy": modifier *= 1.1; break;
                case "homemade": modifier *= 1.0; break;
                default:
                    break;
            }

            return modifier;
        }

        private double ModifyFlourTypeCalories(double modifier)
        {
            switch (this.FlourType.ToLower())
            {
                case "white": modifier *= 1.5; break;
                case "wholegrain": modifier *= 1.0; break;
                default:
                    break;
            }

            return modifier;
        }

        public override string ToString()
        {
            return $"{this.Calories():f2}"; 
        }
    }
}
