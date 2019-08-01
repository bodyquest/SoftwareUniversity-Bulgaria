using EXRC_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double GAIN_VALUE = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Meat) }, GAIN_VALUE);
        }
    }
}
