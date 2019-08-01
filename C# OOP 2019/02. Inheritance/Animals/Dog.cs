namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dog : Animal, IProduceSound
    {

        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
            base.Name = name;
        }


        public string ProduceSound()
        {
            return "Woof!";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
