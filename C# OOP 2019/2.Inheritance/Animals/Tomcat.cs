namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tomcat : Cat, IProduceSound
    {
        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {
        }

        public new string ProduceSound()
        {
            return "MEOW";
        }

        public override string GetResult()
        {
            return base.GetResult() + ProduceSound();
        }
    }
}
