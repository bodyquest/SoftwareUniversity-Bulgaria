namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Cargo
    {
        private int weight;

        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.weight = weight;
        }

        public string Type { get; set; }
    }
}
