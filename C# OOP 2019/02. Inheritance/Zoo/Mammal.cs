namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Mammal : Animal
    {
        public Mammal(string name)
            : base (name)
        {
            
        }

        public string Name { get; set; }
    }
}
