using EXRC_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double GAIN_VALUE = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Meat), nameof(Seeds), nameof(Fruit), nameof(Vegetable) }, GAIN_VALUE);
        }
    }
}
