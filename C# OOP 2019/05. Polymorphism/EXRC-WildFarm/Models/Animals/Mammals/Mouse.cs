using System;
using System.Collections.Generic;
using System.Text;
using EXRC_WildFarm.Models.Foods;

namespace EXRC_WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double GAIN_VALUE = 0.1;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Squeak";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Fruit), nameof(Vegetable) }, GAIN_VALUE);
        }
    }
}
