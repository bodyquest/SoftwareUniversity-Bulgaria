using EXRC_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace EXRC_WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double GAIN_VALUE = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string> { nameof(Meat) }, GAIN_VALUE);
        }
    }
}
