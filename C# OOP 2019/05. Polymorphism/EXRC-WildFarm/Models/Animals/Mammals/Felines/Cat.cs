using EXRC_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double GAIN_VALUE = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Meat), nameof(Vegetable) }, GAIN_VALUE);
        }
    }
}
