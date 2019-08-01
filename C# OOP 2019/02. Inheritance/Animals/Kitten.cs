namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kitten : Cat, IProduceSound
    {
        public Kitten(string name, int age)
            : base(name, age, "Female")
        {
        }

        public new string ProduceSound()
        {
            return "Meow";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
