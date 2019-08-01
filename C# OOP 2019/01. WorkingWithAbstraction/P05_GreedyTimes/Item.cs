namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Item
    {

        private string name;
        private string type;

        public Item(string name, long amount)
        {
            this.Name = name;
            this.Amount = amount;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (this.Name.Length == 3)
                {
                    this.type = "Cash";
                }
                else if (this.Name.ToLower().EndsWith("gem") && this.Name.Length >= 4)
                {
                    this.type = "Gem";
                }
                else if (this.Name.ToLower() == "gold")
                {
                    this.type = "Gold";
                }

                this.type = value;
            }
        }

        public long Amount { get; private set; }

        public override string ToString()
        {
            return $"##{this.Name} - {this.Amount}"; 
        }
    }
}
