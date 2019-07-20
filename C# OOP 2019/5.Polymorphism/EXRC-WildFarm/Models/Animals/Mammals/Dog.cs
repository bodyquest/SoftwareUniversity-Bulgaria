using EXRC_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double GAIN_VALUE = 0.4;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Meat) }, GAIN_VALUE);
        }
    }
}
