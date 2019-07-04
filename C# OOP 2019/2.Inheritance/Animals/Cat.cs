namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cat : Animal, IProduceSound
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
            base.Name = name;
        }


        public string ProduceSound()
        {
            return "Meow meow";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
